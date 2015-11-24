using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 指示データ
/// </summary>
public struct GPDirection
{
    public string sizi; // 4-1 など
    public float time;  // 待ち時間
    public Action callback; // コールバック

    public GPDirection(string s, float t, Action a)
    {
        sizi = s;
        time = t;
        callback = a;
    }
};

/// <summary>
/// 演出Noをキューイングする
/// </summary>
public class ReelController : MonoBehaviour {

    static private ReelController _instance;

    static public ReelController Instance
    {
        get { return _instance; }
    }

    public GameObject GinparaManager;

    Queue _Direction = new Queue();

    void Awake()
    {
        _instance = this;
    }

    public Queue Direction { get { return _Direction; } }

    public Queue EnqueueDirection( string sizi, float time )
    {
        _Direction.Enqueue(new GPDirection(sizi, time, null));
        return _Direction;
    }

    public Queue EnqueueDirection(string sizi, float time, Action callback)
    {
        _Direction.Enqueue(new GPDirection(sizi, time, callback));
        return _Direction;
    }

    public void EndEvent()
    {
        this.gameObject.GetComponent<PlayMakerFSM>().SendEvent("End");
    }
}
