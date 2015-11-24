using HutongGames.PlayMaker;
using UnityEngine;
using System.Collections;

public class HazureKotei : MonoBehaviour {

    static HazureKotei _instance;
    static public HazureKotei Instance { get { return _instance; } }

    void Start () {
        _instance = this;
	}

    bool state = false;

    public bool State { get { return state; } }

    public HazureKotei ON()
    {
        state = true;
        return this;
    }

    public HazureKotei OFF()
    {
        state = false;
        return this;
    }

    [ActionCategory("Ginpara")]
    public class HazureKoteiON : FsmStateAction
    {
        public override void OnEnter()
        {
            HazureKotei.Instance.ON();
        }
    }

    [ActionCategory("Ginpara")]
    public class HazureKoteiOFF : FsmStateAction
    {
        public override void OnEnter()
        {
            HazureKotei.Instance.OFF();
        }
    }

}
