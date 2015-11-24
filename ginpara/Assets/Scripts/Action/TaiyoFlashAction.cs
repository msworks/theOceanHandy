using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class TaiyoFlashActionA : FsmStateAction
{
	public override void OnEnter()
	{
        Kokuti.Instance.KokutiActionA();
        Finish();
    }
}

[ActionCategory("Ginpara")]
public class TaiyoFlashFinish : FsmStateAction
{
    public override void OnEnter()
    {
        Kokuti.Instance.Finish();
        Finish();
    }
}

[ActionCategory("Ginpara")]
public class TaiyoFlashActionB : FsmStateAction
{
    public override void OnEnter()
    {
        //Kokuti.Instance.KokutiActionB();
        Finish();
    }
}
