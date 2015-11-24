using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ヒストリーを１増加する
/// </summary>
[ActionCategory("Ginpara")]
public class AddHistory : FsmStateAction
{
    public override void OnEnter()
    {
        History.Instance.Add();
        Finish();
    }
}

/// <summary>
/// ヒストリーを右にシフトする
/// </summary>
[ActionCategory("Ginpara")]
public class ShiftHistory : FsmStateAction
{
    public override void OnEnter()
    {
        History.Instance.Shift();
        Finish();
    }
}

