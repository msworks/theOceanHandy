using HutongGames.PlayMaker;
using UnityEngine;
using System.Collections;

public class Excange : MonoBehaviour {

    static Excange _instance;
    static public Excange Instance { get { return _instance; } }

    [SerializeField]
    GameObject Uchidashi;

	void Start () {
	    // uchidashiから玉の数を取得
        var num = Uchidashi.GetComponent<PlayMakerFSM>()
                           .FsmVariables.FindFsmInt("tama").Value;

        Display(num);

        _instance = this;
	}

    public void Display(int tamaNum)
    {
        var doller = tamaNum * 2 / 10f;
        CasinoData.Instance.Exchange = doller;
    }

    [ActionCategory("Ginpara")]
    public class SetExchange : FsmStateAction
    {
        public FsmInt TamaNum;

        public override void OnEnter()
        {
            Excange.Instance.Display(TamaNum.Value);
            Finish();
        }
    }
}
