using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class Shoot : FsmStateAction
{
    public GameObject Handle;
    public FsmFloat power;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        Handle.GetComponent<ShootBallTest>().ShootBall(power.Value);
        Finish();
    }
}
