using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 確率変動ログ
/// </summary>
[ActionCategory("Ginpara")]
public class KakuhenLog : FsmStateAction
{
    public FsmInt Kakuhen;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        Debug.Log("*** 確変 残り " + Kakuhen.Value + " ***");
		Finish();
	}


}
