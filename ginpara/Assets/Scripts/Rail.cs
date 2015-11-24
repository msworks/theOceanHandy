using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Rail : MonoBehaviour
{
    [SerializeField] private RailPanel[] railPanels = null;
	[SerializeField] private PictureManager pictureManager = null;
	[SerializeField] private Animation railAnimation = null;
	[SerializeField] private AnimationClip[] anims = null;
	[SerializeField] private UIStretch[] stretchs = null;

    public float anchorValue = 0;

    private float preAnchorValue = 0;
	private float originValue = 0;
	private bool isRolling = false;
	private bool isAct = false;

	public bool IsAnimating { get { return this.railAnimation.isPlaying; } }

	void Start(){
		this.Initialize (1);
		StartCoroutine (this.ResetStretch ());
	}
	
	private IEnumerator ResetStretch(){
		yield return new WaitForSeconds(1);
		foreach(UIStretch str in this.stretchs){
			str.enabled = true;
		}
	}
	
	public void ResetAnchor(int pictureNum)
    {
		this.anchorValue = this.preAnchorValue = 0;
		for (int i = 0; i < this.railPanels.Length; ++i)
        {
			this.railPanels [(this.railPanels.Length - 1) - i].Anchor.relativeOffset = new Vector2 ((this.railPanels.Length - 1) - ((this.anchorValue + i + this.originValue) % this.railPanels.Length), 0);
			this.railPanels [(this.railPanels.Length - 1) - i].Reset();
		}
		
		var dic = this.pictureManager.Initialize (pictureNum, this.railPanels);
		
		foreach(RailPanel panel in this.railPanels)
        {
            panel.spriteName = dic[(int)panel.Anchor.relativeOffset.x];
        }
	}
	
	void Update()
    {
		if(this.isRolling){
			this.anchorValue += Time.deltaTime * 32f;
		}
		
		if ((this.anchorValue + this.originValue) != this.preAnchorValue  &&  (this.anchorValue + this.originValue) > this.preAnchorValue)
        {
			for (int i = 0; i < this.railPanels.Length; ++i)
            {
				this.railPanels [(this.railPanels.Length - 1) - i].Anchor.relativeOffset = new Vector2 ((this.railPanels.Length - 1) - ((this.anchorValue + i + this.originValue) % this.railPanels.Length), 0);
			}
			this.preAnchorValue = this.anchorValue + this.originValue;
		}
		if(this.isRolling  &&  this.anchorValue > 5f)
			this.anchorValue = this.preAnchorValue = 0;
	}

	void Initialize(int pictureNum)
    {
		this.anchorValue = this.preAnchorValue = 0;

		this.railPanels[0].Anchor.relativeOffset = new Vector2(0, 0);
		this.railPanels[1].Anchor.relativeOffset = new Vector2(1, 0);
		this.railPanels[2].Anchor.relativeOffset = new Vector2(2, 0);
		this.railPanels[3].Anchor.relativeOffset = new Vector2(3, 0);
		this.railPanels[4].Anchor.relativeOffset = new Vector2(4, 0);
		this.railPanels[5].Anchor.relativeOffset = new Vector2(5, 0);
		
		var dic = this.pictureManager.Initialize (pictureNum, this.railPanels);
		
		foreach(RailPanel panel in this.railPanels)
        {
            //panel.MainTexture = dic[(int)panel.Anchor.relativeOffset.x];
            panel.spriteName = dic[(int)panel.Anchor.relativeOffset.x];
        }
		
		//Debug.Log (this.gameObject.name+"を"+pictureNum.ToString()+"で初期化");
	}
	
	public IEnumerator RailStart(System.Action callback)
    {
		while(this.isAct)
        {
			yield return null;
		}
		this.isAct = true;

		this.railAnimation.clip = this.anims[0];
		this.originValue = this.anchorValue;
		this.anchorValue = 0;
		this.railAnimation.Play ();
		while(this.railAnimation.isPlaying){
			yield return null;
		}
		this.anchorValue = (this.anchorValue + this.originValue);
		this.originValue = 0;
		this.isRolling = true;
		this.isAct = false;
		if(callback != null) callback();
		yield break;
	}
	
	public IEnumerator RailStop(int targetNum, System.Action callback)
    {
		while(this.isAct)
        {
			yield return null;
		}
		this.isAct = true;

		while(this.railAnimation.isPlaying){
			yield return null;
		}

		this.ResetAnchor(this.pictureManager.StopStartNum(targetNum));
		this.isRolling = false;
		this.railAnimation.clip = this.anims[1];
		this.originValue = (int)this.anchorValue;
		this.anchorValue = 0;
		this.railAnimation.Play ();
		while(this.railAnimation.isPlaying){
			yield return null;
		}
		
		this.anchorValue = (this.anchorValue + this.originValue);
		this.originValue = 0;
		this.isAct = false;
        if (callback != null)
        {
            callback();
        }

		yield break;
	}

    /// <summary>
    /// ２週目で停止
    /// </summary>
    /// <param name="targetNum"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator StopAfter1Turn(int targetNum, System.Action callback)
    {
        float totalTime = (1f / 3f) * (float)5;
        while (totalTime > 0)
        {
            float deltaTime = Time.deltaTime;
            totalTime -= deltaTime;
            if (totalTime >= 0) this.anchorValue += deltaTime * 3f;
            else this.anchorValue += (totalTime + deltaTime) * 3f;
            yield return null;
        }

        while (this.isAct)
        {
            yield return null;
        }
        this.isAct = true;

        while (this.railAnimation.isPlaying)
        {
            yield return null;
        }

        this.ResetAnchor(this.pictureManager.StopStartNum(targetNum));
        this.isRolling = false;
        this.railAnimation.clip = this.anims[1];
        this.originValue = (int)this.anchorValue;
        this.anchorValue = 0;
        this.railAnimation.Play();
        while (this.railAnimation.isPlaying)
        {
            yield return null;
        }

        this.anchorValue = (this.anchorValue + this.originValue);
        this.originValue = 0;
        this.isAct = false;
        if (callback != null)
        {
            callback();
        }

        yield break;
    }

	public IEnumerator RailReach(int certainNum, System.Action callback)
    {
		while(this.isAct)
        {
			yield return null;
		}
		this.isAct = true;

		this.ResetAnchor(1);
		this.isRolling = false;
		float totalTime = (1f / 3f) * (float)certainNum;
		while(totalTime > 0){
			float deltaTime = Time.deltaTime;
			totalTime -= deltaTime;
			if(totalTime >= 0) this.anchorValue += deltaTime * 3f;
			else this.anchorValue += (totalTime + deltaTime) * 3f;
			yield return null;
		}

        // 泡、魚群があれば演出
        Action action;
        while ((action = GinparaManager.Instance.DequeueGensokuAction()) != null)
        {
            action();
        }

		totalTime = 1;
		while(totalTime > 0){
			float deltaTime = Time.deltaTime;
			totalTime -= deltaTime;
			if(totalTime >= 0) this.anchorValue += deltaTime;
			else if(totalTime < 0) this.anchorValue += totalTime;
			yield return null;
		}

		this.isAct = false;
		if(callback != null) callback();
		yield break;
	}
	
	public IEnumerator RailSuperReach(int certainNum, int lowNum, System.Action callback)
    {
		while(this.isAct)
        {
			yield return null;
		}
		this.isAct = true;

		this.ResetAnchor(1);
		this.isRolling = false;
		float totalTime = (1f / 3f) * (float)certainNum;
		while(totalTime > 0){
			float deltaTime = Time.deltaTime;
			totalTime -= deltaTime;
			if(totalTime >= 0) this.anchorValue += deltaTime * 3f;
			else this.anchorValue += (totalTime + deltaTime) * 3f;
			yield return null;
		}

        // 煽り音発声
        AudioManager.Instance.PlaySELoop(11);

        // SPリーチ（最終煽り中）エフェクト
        Effect.Instance.SendEvent("SPリーチ（最終煽り中）");

        // 泡、魚群があれば演出
        Action action;
        while ((action = GinparaManager.Instance.DequeueGensokuAction()) != null)
        {
            action();
        }

		totalTime = (float)lowNum * 2f;
		while(totalTime > 0){
			float deltaTime = Time.deltaTime;
			totalTime -= deltaTime;
			if(totalTime >= 0) this.anchorValue += deltaTime / 2f;
			else this.anchorValue += (totalTime + deltaTime) / 2f;
			yield return null;
		}

        // 煽り音停止
        AudioManager.Instance.StopSE(11);

		this.isAct = false;
        if (callback != null)
        {
            callback();
        }

		yield break;
	}
	
	public IEnumerator RailVitaStop(int moveNum, System.Action callback)
    {
        // ハズレ→再始動の発声
        AudioManager.Instance.PlaySE(12);

		while(this.isAct){
			yield return null;
		}
		this.isAct = true;

		float time = 0.5f;
		while(time > 0){
			time -= Time.deltaTime;
			yield return null;
		}

		this.anchorValue = this.preAnchorValue = (int)(this.anchorValue + 0.5f);

		float totalTime = (float)moveNum / 5f;
		while(totalTime > 0){
			float deltaTime = Time.deltaTime;
			totalTime -= deltaTime;
			if(totalTime >= 0) this.anchorValue += deltaTime * 5f;
			else this.anchorValue += (totalTime + deltaTime) * 5f;
			yield return null;
		}

		this.isAct = false;
		if(callback != null) callback();
		yield break;
	}
	
	public void StartAnime(int pictureNum){
		this.pictureManager.StartAnime (pictureNum);
	}
	
	public void ChangeHitPicture(int pictureNum){
		this.pictureManager.ChangeHitPicture(pictureNum);
	}
	
	public int[] RecodePanelNum {
        get
        {
            return this.pictureManager.RecodePanelNum;
        }
    }
}
