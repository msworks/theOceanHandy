using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class HappyFish : FsmStateAction
{
    public FsmString Zugara;

    public override void OnEnter()
    {
        var ensyutuNo = "902-" + Zugara.Value;
        GinparaManager.GetInstance().Order(ensyutuNo, ()=>Finish());
    }
}
