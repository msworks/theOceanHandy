using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class Lost : FsmStateAction
{
    public GameObject DirectionController;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        DirectionController.GetComponent<ReelController>().EnqueueDirection("202", 0f);
        DirectionController.GetComponent<ReelController>().EnqueueDirection("201-2", 0f);
        Finish();
    }
}

[ActionCategory("Ginpara")]
public class Win : FsmStateAction
{
    public GameObject DirectionController;

    // Code that runs on entering the state.
    public override void OnEnter()
    {
        DirectionController.GetComponent<ReelController>().EnqueueDirection("203", 0f);
        DirectionController.GetComponent<ReelController>().EnqueueDirection("204", 2f);
        DirectionController.GetComponent<ReelController>().EnqueueDirection("301", 1f);
        DirectionController.GetComponent<ReelController>().EnqueueDirection("302", 0f);
    }
}

