using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// •Û—¯ƒ‰ƒ“ƒv‚ğnum‚Ì”‚¾‚¯‚Â‚¯‚é
/// </summary>
[ActionCategory("Ginpara")]
public class HoryuLamp : FsmStateAction
{
    public GameObject[] Lamps;
    public FsmInt num;
	
    /// <summary>
    /// ‘JˆÚ‚Ìˆ—
    /// </summary>
	public override void OnEnter()
	{
        // “_“”
        Lamps.ToList().Take(num.Value).ToList().ForEach(lamp=>{
            lamp.GetComponent<UISprite>().alpha = 1;
        });

        // Á“”
        Lamps.ToList().Skip(num.Value).ToList().ForEach(lamp =>
        {
            lamp.GetComponent<UISprite>().alpha = 0f;
        });

        Finish();
	}


}
