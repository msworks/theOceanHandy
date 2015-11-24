using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 演出に演出Noを渡す
/// </summary>
[ActionCategory("Ginpara")]
public class ReelDirection : FsmStateAction
{
    public GameObject GinparaManager;   // 出力先
    public GameObject ReelController;   // 入力元
    public FsmFloat WaitTime;

	// Code that runs on entering the state.
	public override void OnEnter()
	{
        var data = (GPDirection)ReelController.GetComponent<ReelController>().Direction.Dequeue();

        GinparaManager.GetComponent<GinparaManager>().Order(data.sizi, data.callback);

        // 待ち時間を取得
        WaitTime.Value = data.time;

        Finish();
	}

}

/// <summary>
/// 演出データのキューが残っているかチェック
/// </summary>
[ActionCategory("Ginpara")]
public class CheckReelDirection : FsmStateAction
{
    public GameObject ReelController;   // 入力元
    public FsmEvent ari;
    public FsmEvent nasi;

    // 演出データがあればありイベントを、なければなしイベントを発行
    public override void OnEnter()
    {
        var data = ReelController.GetComponent<ReelController>().Direction.Count;
        Fsm.Event(data != 0 ? ari : nasi);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        var data = ReelController.GetComponent<ReelController>().Direction.Count;
        Fsm.Event(data != 0 ? ari : nasi);
    }
}
