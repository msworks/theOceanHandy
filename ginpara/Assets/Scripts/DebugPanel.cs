using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DebugPanel : MonoBehaviour {

    public Transform ShowPostion;
    public Transform HidePostion;

    private static DebugPanel _instance;

    public static DebugPanel Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    public void Show()
    {
        Move(ShowPostion);
    }

    public void Hide()
    {
        Move(HidePostion);
    }

    private void Move(Transform transform)
    {
        var p = transform.position;
        var table = iTween.Hash(
            "x", p.x,
            "y", p.y,
            "z", p.z,
            "time", 1.0f
        );
        iTween.MoveTo(gameObject, table);
    }

    [ActionCategory("Ginpara")]
    public class ShowDebugPanel : FsmStateAction
    {
        public override void OnEnter()
        {
            DebugPanel.Instance.Show();
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class HideDebugPanel : FsmStateAction
    {
        public override void OnEnter()
        {
            DebugPanel.Instance.Hide();
            Finish();
        }
    }
}

