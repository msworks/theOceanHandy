using HutongGames.PlayMaker;
using UnityEngine;
using System.Collections;

/// <summary>
/// データランプ
/// </summary>
public class CasinoDataLamp : MonoBehaviour {

    static CasinoDataLamp _instance;
    static public CasinoDataLamp Instance { get { return _instance; } }

    /// <summary>
    /// インスペクタから設定
    /// </summary>
    public GameObject right;
    public GameObject left;

	void Start () {
        _instance = this;
	}

	public void On()
    {
        onFlg = true;
        StartCoroutine(OnCore());
    }

    public void Off(float delayTime)
    {
        StartCoroutine(OffCore(delayTime));
    }

    bool onFlg = false;

    IEnumerator OnCore()
    {
        var Counter = 0;

        var rightSprite = right.GetComponent<UISprite>();
        var leftSprite = left.GetComponent<UISprite>();

        while(onFlg){
            yield return null;

            var r = (float)Counter * 3.14f / 60f * 10f;
            var v = Mathf.Sin(r);
            var v2 = v * -1f;

            rightSprite.alpha = v;
            leftSprite.alpha = v2;

            Counter++;
        }

        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delayTime">待ち時間（単位：秒）</param>
    /// <returns></returns>
    IEnumerator OffCore(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        onFlg = false;
    }


    [ActionCategory("Ginpara")]
    public class DataLampOn : FsmStateAction
    {
        public override void OnEnter()
        {
            CasinoDataLamp.Instance.On();
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class DataLampOff : FsmStateAction
    {
        public FsmFloat delayTime;

        public override void OnEnter()
        {
            CasinoDataLamp.Instance.Off(delayTime.Value);
            Finish();
        }
    }
}
