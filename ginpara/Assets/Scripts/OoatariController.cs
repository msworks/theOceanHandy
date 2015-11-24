using UnityEngine;
using System.Collections;

public class OoatariController : MonoBehaviour {

    static private OoatariController _instance;

	void Start () {
        _instance = this;
	}

	static public OoatariController Instance{ get { return _instance; } }

    public string AtariZugara{
        get {
            return this.gameObject.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmString("大当たり図柄").Value.ToString();
        }
    }

    public void Ooatari(int AtariZugara)
    {
        this.gameObject.GetComponent<PlayMakerFSM>().FsmVariables.FindFsmString("大当たり図柄").Value =
            AtariZugara.ToString();
        this.gameObject.GetComponent<PlayMakerFSM>().SendEvent("大当たり");
    }
}
