using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AutoButton : MonoBehaviour {

    public enum MODE
    {
        SEMI_AUTO,
        FULL_AUTO,
    }

    public float LeftPower = 0.415f;
    public float rightPower = 1.0f;

    public GameObject Horyu;
    public GameObject Kenri;
    public GameObject OoatariController;
    public GameObject Handle;
    public UISlider Slider;

    private static AutoButton _instance;

    private bool autoSwitch = false;
    private MODE mode = MODE.SEMI_AUTO;

    public static AutoButton Instance
    {
        get { return _instance; }
    }

    public bool isAuto { get { return autoSwitch; } }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        StartCoroutine(routine());
    }

    public void On(MODE mode)
    {
        autoSwitch = true;
        this.mode = mode;
    }

    public void Off()
    {
        autoSwitch = false;
    }

    IEnumerator routine()
    {
        var HoryuFSM = Horyu.GetComponent<PlayMakerFSM>();
        var KenriFSM = Kenri.GetComponent<PlayMakerFSM>();
        var OoatariFSM = OoatariController.GetComponent<PlayMakerFSM>();
        var HandleFSM = Handle.GetComponent<PlayMakerFSM>();

        while (true)
        {
            if (autoSwitch)
            {
                //◆オート仕様
                //［玉発射]
                //①権利発生中、大当たり待機中、大当たりＲＯＵＮＤ中は玉発射
                //②保留3以下（保留4で玉発射停止）は玉発射
                //※優先順位は①＞②
                //[左打ち→右打ち]
                //①権利獲得成功で右打ち（最大右）
                //[右打ち→左打ち]
                //①大当たり最終ラウンド終了で左打ち
                var isKenri = !KenriFSM.ActiveStateName.Equals("Listen") ? true : false;
                var isOoatariTaiki = OoatariFSM.ActiveStateName.Equals("メッセージ待ち") ? true : false;
                var isOoatariRound = KenriFSM.ActiveStateName.Equals("ラウンド中") ? true : false;
                var horyusu = HoryuFSM.FsmVariables.FindFsmInt("保留カウント").Value;
                var isMigiuti = !KenriFSM.ActiveStateName.Equals("Listen") ? true : false;
                var isShoot = (isKenri || isOoatariTaiki || isOoatariRound) ? true : false;

                if (!isShoot)
                {
                    isShoot = horyusu <= 3 ? true : false;
                }

                // セミオートではぶっぱ
                if (mode == MODE.SEMI_AUTO)
                {
                    isShoot = true;
                }

                if (isShoot)
                {
                    OnHandle(HandleFSM);
                }
                else
                {
                    OffHandle(HandleFSM);
                }

                if (isMigiuti)
                {
                    ToMigiuti();
                }
                else
                {
                    ToHidariuti();
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnHandle(PlayMakerFSM fsm){
        if (fsm.ActiveStateName.Equals("OFF"))
        {
            fsm.SendEvent("TapHandle");
        }
    }

    private void OffHandle(PlayMakerFSM fsm)
    {
        if (fsm.ActiveStateName.Equals("ON"))
        {
            fsm.SendEvent("TapHandle");
        }
    }

    private void ToMigiuti()
    {
        Slider.value = rightPower;
    }

    private void ToHidariuti()
    {
        Slider.value = LeftPower;
    }

    [ActionCategory("Ginpara")]
    public class OnSemiAutoButton : FsmStateAction
    {
        public override void OnEnter()
        {
            AutoButton.Instance.On(MODE.SEMI_AUTO);
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class OnFullAutoButton : FsmStateAction
    {
        public override void OnEnter()
        {
            AutoButton.Instance.On(MODE.FULL_AUTO);
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class OffAutoButton : FsmStateAction
    {
        public override void OnEnter()
        {
            AutoButton.Instance.Off();
            Finish();
        }
    }

}
