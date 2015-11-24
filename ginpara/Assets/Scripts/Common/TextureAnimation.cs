using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TextureAnimation : MonoBehaviour
{
    [SerializeField] private UITexture uiTexture = null;
	[SerializeField] private List<Texture> textureList = null;
	[SerializeField] private float intervalTime = 0;
	[SerializeField] private float totalTime = 0;
	[SerializeField] private bool isLoop = false;
	private int currentNum = 0;
	private bool isAnimating = false;

	public UITexture UiTexture { get { return this.uiTexture; } set { this.uiTexture = value; } }
	public bool IsAnimating{ get { return this.isAnimating; } }
	public float IntervalTime { get {return this.intervalTime; }  set { this.intervalTime = value; } }
	public float TotalTime { get { return this.totalTime; } set { this.totalTime = value; } }
	public bool IsLoop { get { return this.isLoop; } set { this.isLoop = value;} }
	public List<Texture> TextureList { get { return this.textureList; } set { this.textureList = value; } }

	void Start ()
	{
		if (this.uiTexture != null)
			this.uiTexture = this.GetComponent<UITexture> ();
		
		if (this.textureList.Count == 0)
			Debug.Log(this.gameObject.name+"のTextureAnimation-textureListに画像が設定されていません。");
	}
	
	public void Play(System.Action callback)
    {
		this.isAnimating = true;
		StartCoroutine (this.TextureAnimating (callback));
	}

    public void Stop(Action callback)
    {
        this.isAnimating = false;
        if (callback != null) { callback(); }
    }

	private IEnumerator TextureAnimating(System.Action callback)
    {

        if (this.textureList.Count <= this.currentNum)
        {
            Debug.LogWarning("textureList index error");
            this.currentNum = this.textureList.Count - 1;
        }

        if (this.textureList[this.currentNum] != null)
        {
            this.uiTexture.mainTexture = this.textureList[this.currentNum];
        }

		++this.currentNum;
		var timeElapsed = 0f;
		var recodeTime = 0f;

		while(timeElapsed < this.totalTime  ||  this.totalTime == -1)
        {
            if (this.isAnimating == false)
            {
                break;
            }

			if(timeElapsed - recodeTime > this.intervalTime)
            {
				recodeTime = timeElapsed;
				if(this.textureList.Count != this.currentNum  &&  this.textureList[this.currentNum] != null) this.uiTexture.mainTexture = this.textureList[this.currentNum];
				if((this.textureList.Count - 1) > this.currentNum)
					++this.currentNum;
				else if(this.isLoop)
					this.currentNum = 0;
			}
			timeElapsed += Time.deltaTime;
			yield return null;
		}

		this.currentNum = 0;
		this.isAnimating = false;
		this.transform.gameObject.SetActive (false);
		if(callback != null) callback();
	}
}
