using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 泡演出クラス
/// </summary>
public class Bubble : MonoBehaviour {

    static Bubble _instance;
    static public Bubble Instance { get { return _instance; } }

    void Start()
    {
        _instance = this;
    }

    public Bubble Rise()
    {
        GetComponent<Animator>().SetTrigger("Start");
        
        return this;
    }

}
