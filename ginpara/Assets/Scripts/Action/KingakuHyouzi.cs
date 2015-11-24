using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �~�\��
/// </summary>
[ActionCategory("Ginpara")]
public class YenHyozi : FsmStateAction
{
    public FsmInt Yen;
	
	public override void OnEnter()
	{
        Fsm.GameObject.GetComponent<CasinoData>().Exchange = (float)Yen.Value;
		Finish();
	}
}

/// <summary>
/// �h���\��
/// </summary>
[ActionCategory("Ginpara")]
public class DollerHyozi : FsmStateAction
{
    public FsmInt Yen;

    public override void OnEnter()
    {
        // ���[�g�ϊ�
        var doller = (float)Yen.Value / 120f;
        Fsm.GameObject.GetComponent<CasinoData>().Exchange = doller;
        Finish();
    }
}