using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Effect : MonoBehaviour {

    public GameObject body;

    static private Effect _instance;

    static public Effect Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    public void SendEvent(string msg)
    {
        GetComponent<PlayMakerFSM>().SendEvent(msg);
        body.GetComponent<PlayMakerFSM>().SendEvent(msg);
    }
}

[ActionCategory("Ginpara")]
public class EffectAction : FsmStateAction
{
    public FsmString ev;

    public override void OnEnter()
    {
        Effect.Instance.SendEvent(ev.Value);
        Finish();
    }
}