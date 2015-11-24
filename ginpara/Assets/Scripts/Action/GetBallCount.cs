using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class GetBallCount : FsmStateAction
{
    public FsmInt BallCount;

	public override void OnEnter()
	{
        BallCount.Value = Ball.Count;

        Finish();
    }
}
