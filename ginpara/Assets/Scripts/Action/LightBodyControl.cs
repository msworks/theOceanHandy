using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class LightBodyOn : FsmStateAction
{
    public GameObject Body;
    public FsmFloat   cycle;
    public FsmFloat   power;
    public FsmBool    outer;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        Body.GetComponent<LightBody>().ON(cycle.Value, power.Value, outer.Value);
        Finish();
	}
}

[ActionCategory("Ginpara")]
public class LightBodyOff : FsmStateAction
{
    public GameObject Body;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        Body.GetComponent<LightBody>().OFF();
        Finish();
    }
}