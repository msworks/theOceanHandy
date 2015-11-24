using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ���E���h�J�n
/// </summary>
[ActionCategory("Ginpara")]
public class Round : FsmStateAction
{
    public FsmInt round;
    public GameObject DirectionController;

    public override void OnEnter()
    {
        Syokyu.Syokyu15Count = 0;

        var siziList = new List<String> {
            "402-" + round.Value.ToString(),
            "401-" + OoatariController.Instance.AtariZugara,
        };

        foreach( var sizi in siziList ){
            GinparaManager.Instance.Order(sizi);
        }

        RoundDisplay.Instance.display(round.Value);

        Finish();
    }
}

/// <summary>
/// ���E���h�J�n
/// </summary>
[ActionCategory("Ginpara")]
public class WaitRound : FsmStateAction
{
    public override void OnEnter()
    {
        var siziList = new List<String> {
            "301",
            "401-0",
            "402-0",
        };

        foreach (var sizi in siziList)
        {
            GinparaManager.Instance.Order(sizi);
        }

        Finish();
    }
}


/// <summary>
/// ���E���h�I��
/// </summary>
[ActionCategory("Ginpara")]
public class ExitRound : FsmStateAction
{
    public GameObject DirectionController;

    public override void OnEnter()
    {
        DirectionController.GetComponent<ReelController>().EnqueueDirection("401-0", 0f);
        DirectionController.GetComponent<ReelController>().EnqueueDirection("402-0", 0f);
        DirectionController.GetComponent<ReelController>().EnqueueDirection("403", 0f);

        RoundDisplay.Instance.hide();

        Finish();
    }
}


/// <summary>
/// ���E���h�I��
/// </summary>
[ActionCategory("Ginpara")]
public class  ReturnDisplay : FsmStateAction
{
    public GameObject DirectionController;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        var KenriKaisu = MainLogic.Instance.KenriKaisu;

        if (KenriKaisu != 0)
        {
            // �m���ϓ��w�i
            DirectionController.GetComponent<ReelController>().EnqueueDirection("103", 1f );
        }
        else
        {
            // �ʏ�w�i
            DirectionController.GetComponent<ReelController>().EnqueueDirection("101", 1f);
        }

        Finish();
    }
}
