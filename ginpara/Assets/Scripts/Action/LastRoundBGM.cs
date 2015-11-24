using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class LastRoundBGM : FsmStateAction
{
    public FsmInt Round;
    public FsmInt LastRound;

	public override void OnEnter()
	{
        if (Round.Value == LastRound.Value)
        {
            // 最終RoundのBGMはループしない
            AudioManager.Instance.PlayBGMOneShot(7);
            //AudioManager.Instance.PlayBGMLoop(7);
        }

        Finish();
    }
}
