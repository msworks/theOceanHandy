using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class LightPartsOn : FsmStateAction
{
    public GameObject[] Parts;
    public FsmFloat   cycle;
    public FsmFloat   power;
    public FsmBool outer;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        Parts.ToList().ForEach(part =>
        {
            part.GetComponent<LightBody>().ON(cycle.Value, power.Value, outer.Value);
        });
        Finish();
	}
}

[ActionCategory("Ginpara")]
public class LightPartsOff : FsmStateAction
{
    public GameObject[] Parts;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        Parts.ToList().ForEach(part =>
        {
            part.GetComponent<LightBody>().OFF();
        });
        Finish();
    }
}