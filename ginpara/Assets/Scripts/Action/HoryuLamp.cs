using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 保留ランプをnumの数だけつける
/// </summary>
[ActionCategory("Ginpara")]
public class HoryuLamp : FsmStateAction
{
    public GameObject[] Lamps;
    public FsmInt num;
	
    /// <summary>
    /// 遷移時の処理
    /// </summary>
	public override void OnEnter()
	{
        // 点灯
        Lamps.ToList().Take(num.Value).ToList().ForEach(lamp=>{
            lamp.GetComponent<UISprite>().alpha = 1;
        });

        // 消灯
        Lamps.ToList().Skip(num.Value).ToList().ForEach(lamp =>
        {
            lamp.GetComponent<UISprite>().alpha = 0f;
        });

        Finish();
	}


}
