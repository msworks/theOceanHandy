using HutongGames.PlayMaker;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ランプを光らせる
/// </summary>
public class LightLamp : MonoBehaviour {

    public GameObject right;
    public GameObject left;

    private bool LightFlg;
    private int Counter = 0;

	// Use this for initialization
	void Start () {
        LightFlg = false;
        Counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!LightFlg) return;

        Counter++;

        var r = (float)Counter * 3.14f / 60f * 10f;
        var v = Mathf.Sin(r);
        var v2 = v * -1f;

        right.GetComponent<UISprite>().alpha = v;
        left.GetComponent<UISprite>().alpha = v2;

	}

    public void ON()
    {
        LightFlg = true;
        Counter = 0;
    }

    public void OFF()
    {
        LightFlg = false;
        Counter = 0;
        right.GetComponent<UISprite>().alpha = 0;
        left.GetComponent<UISprite>().alpha = 0;
    }

}
