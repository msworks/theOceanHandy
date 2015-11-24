using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// テストという名前をつけてしまっているが本番
/// </summary>
public class ShootBallTest : MonoBehaviour {

    public GameObject BallPrefab;
    public GameObject BodyPath;
    public GameObject ShootPosition;

    public GameObject Uchidashi;

    private float yureMin;
    private float yureMax;

    // テスト用
    Vector2 ShootPower = new Vector2(7.5f, 7.5f);

	// 初期化
	void Start () {

	}

    // 玉を発射する
    public void ShootBall(float power)
    {
        // パワー０なら打たない
        if (power == 0) return;

        var uchi = Uchidashi.GetComponent<ShootPowerEditor>();

        // パワーを変換
        power = uchi.Power_MIN + power * (uchi.Power_MAX-uchi.Power_MIN);

        ShootPower = new Vector2(power, power);

        yureMin = 1 - uchi.Yure;
        yureMax = 1 + uchi.Yure;



        float rndp = UnityEngine.Random.Range(yureMin, yureMax);

        var ball = NGUITools.AddChild(BodyPath, BallPrefab);
        ball.transform.position = ShootPosition.transform.position;
        ball.GetComponent<Rigidbody2D>().velocity = ShootPower * rndp;
        //ball.rigidbody2D.velocity = ShootPower * rndp;

        ball.GetComponent<UISprite>().depth = 980;
    }

    [ActionCategory("Ginpara")]
    public class DisplaySadama : FsmStateAction
    {
        public UILabel sadama;

        public override void OnEnter()
        {
            var tama = Fsm.GetFsmInt("tama").Value - 10000;

            sadama.text = "差玉：" + tama.ToString();
            
            Finish();
        }
    }
}
