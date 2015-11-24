using UnityEngine;
using System.Collections;

/// <summary>
/// 筐体、ランプを光らせる
/// </summary>
public class LightBody : MonoBehaviour {

    public GameObject inside;
    public GameObject outside;

    private UISprite insideSprite;
    private UISprite outsideSprite;

    private int Counter = 0;
    private bool LightFlg = false;
    private float mPower = 0.0f;
    private float mCycle = 0.0f;

    private bool outerFlg = false;

    /// <summary>
    /// 開始時処理
    /// </summary>
	void Start () {
        if (inside) insideSprite = inside.GetComponent<UISprite>();
        if (outside) outsideSprite = outside.GetComponent<UISprite>();
	}
	
    /// <summary>
    /// 筐体をてれこで光らせる
    /// </summary>
	void Update () {
        if (!LightFlg) return; 
        
        Counter++;

        var r = (float)Counter * Mathf.PI / 60f * mCycle;
        if (mCycle == 0f)
        {
            r = Mathf.PI / 2f;
        }

        var v  = Mathf.Sin(r) * mPower;
        var v2 = Mathf.Sin(r+Mathf.PI/2) * mPower;
        if (mCycle == 0f)
        {
            v2 = v;
        }

        v = Mathf.Abs(v);
        v2 = Mathf.Abs(v2);

        if (insideSprite) insideSprite.GetComponent<UISprite>().alpha = v;

        if (!outerFlg)
        {
            //v2 = 0.0f;
        }

        if (outsideSprite) outsideSprite.GetComponent<UISprite>().alpha = v2;

	}

    /***
     * 点灯
     * cycle : 何ヘルツで光るか
     * power : 光る強さ（１：最高　０：消灯）
     */
    public void ON( float cycle, float power, bool outer=true )
    {
        LightFlg = true;
        Counter = 0;
        mCycle = cycle;
        mPower = power;
        outerFlg = outer;
    }

    /// <summary>
    /// 消灯
    /// </summary>
    public void OFF()
    {
        LightFlg = false;
       
        Counter = 0;
        if (insideSprite) insideSprite.alpha = 0;
        if (outsideSprite) outsideSprite.alpha = 0;
    }

}
