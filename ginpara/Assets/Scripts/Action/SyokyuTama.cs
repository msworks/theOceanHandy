using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class SyokyuTama : FsmStateAction
{
    public FsmInt num;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        var Uchidashi = GameObject.FindGameObjectWithTag("Uchidashi");
        Uchidashi.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmInt("tama").Value += num.Value;
		Finish();
	}


}
