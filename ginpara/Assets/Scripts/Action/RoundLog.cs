using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class RoundLog : FsmStateAction
{
    public FsmInt Round;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        Debug.Log("*** Round " + Round.Value + " ***");
		Finish();
	}


}
