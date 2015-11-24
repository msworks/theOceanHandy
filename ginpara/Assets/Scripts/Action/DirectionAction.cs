using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class DirectionGM : FsmStateAction
{
    public FsmString Sizi;
    
    // Code that runs on entering the state.
    public override void OnEnter()
    {
        GinparaManager.GetInstance().Order(Sizi.Value);
        Finish();
    }
}

[ActionCategory("Ginpara")]
public class DirectionGMCallBack : FsmStateAction
{
    public FsmString Sizi;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        GinparaManager.GetInstance().Order(Sizi.Value, Finish);
    }
}
