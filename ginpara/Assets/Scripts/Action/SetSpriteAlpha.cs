using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// スプライトのアルファ値をセットする
/// </summary>
[ActionCategory("Ginpara")]
public class SetSpliteAlpha : FsmStateAction
{
    public GameObject sprite;
    public FsmEvent finishEvent;
    public FsmFloat TimeLength;
    public FsmFloat AlphaFrom;
    public FsmFloat AlphaTo;

    private float startTime;
    private float currentTime;
    private float endTime;

	// Code that runs on entering the state.
	public override void OnEnter()
	{
        currentTime = 0f;
        sprite.GetComponent<UISprite>().alpha = AlphaFrom.Value;
	}

    public override void OnUpdate()
    {
        currentTime += Time.deltaTime;
        sprite.GetComponent<UISprite>().alpha =
            AlphaFrom.Value + (AlphaTo.Value - AlphaFrom.Value) * (currentTime / TimeLength.Value);

        if (currentTime > TimeLength.Value)
        {
            Fsm.Event(finishEvent);
        }
    }

}
