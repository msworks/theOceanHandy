using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ginpara
{

    /// <summary>
    /// 大当たり抽選を行う
    /// </summary>
    [ActionCategory("Ginpara")]
    public class DrawLotBigRound : FsmStateAction
    {
        public FsmInt HoryuSu;
        public FsmInt KenriKaisu;

        public FsmBool IsOoatari;
        public FsmInt ReachLine;
        public FsmInt ReachPattern;

        public GameObject ReelController;
        public GameObject DirectionController;
        public GameObject Atacker;
        public GameObject MarinController;

        // DEBUG
        public FsmBool ForceNormalReach;
        public FsmBool ForceSPReach;
        public FsmBool ForceOoatari;
        public FsmBool ForceSP3;
        public FsmBool ForceSaishidou;

        struct Sizi
        {
            public string EnsyutuNo;
            public float waitTime;
        }

        List<Sizi> H012Start = new List<Sizi>()
        {
            new Sizi{ EnsyutuNo="1", waitTime=0f },
            new Sizi{ EnsyutuNo="2", waitTime=0f },
            new Sizi{ EnsyutuNo="3", waitTime=8f },
        };

        List<Sizi> H34Start = new List<Sizi>()
        {
            new Sizi{ EnsyutuNo="1", waitTime=0f },
            new Sizi{ EnsyutuNo="2", waitTime=0f },
            new Sizi{ EnsyutuNo="3", waitTime=2f },
        };

	    public override void OnEnter()
	    {
            var atariZugara = -1;

            var result = MainLogic.Instance.DrawLot(
                HoryuSu.Value,
                KenriKaisu.Value,
                ForceNormalReach.Value,
                ForceSPReach.Value,
                ForceOoatari.Value,
                ForceSP3.Value,
                ForceSaishidou.Value
            );

            // 告知
            // 大当り確定時、1/3の確率で告知を行う
            if (result.isOOatari)
            {
                Kokuti.Instance.KokutiActionA();
            }

            //Debug.Log("リーチライン:" + result.reachLine);
            //Debug.Log("リーチパターン:" + result.reachPattern);
            //Debug.Log("リーチパターン名:" + result.reachPatternName);

            // 演出完了コールバック
            Action callback = () =>
            {
                ReelController.GetComponent<ReelController>().EndEvent();
                AudioManager.Instance.PlaySE(14);   // 停止音
                AudioManager.Instance.StopBGM();
            };

            List<Sizi> StartList;
            if (HoryuSu.Value < 3)
            {
                StartList = H012Start;
            }
            else
            {
                StartList = H34Start;
            }

            // スタート演出
            StartList.ForEach(s =>
            {
                DirectionController.GetComponent<ReelController>().EnqueueDirection(s.EnsyutuNo, s.waitTime);
            });

            // 停止演出
            if (result.reachPattern == -1){
                // バラケ目
                var reels = Reel.ChooseBarakeme();
                DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 1f);
                DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 1f);
                DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 0.5f, callback);
            }
            else
            {
                // リールの止まる位置を取得
                ReelElement[] reels;
                if (result.isOOatari)
                {
                    reels = Reel.ChooseOoatari(result, out atariZugara);
                }
                else if (result.reachPatternName.Contains("SP"))
                {
                    reels = Reel.ChooseSP(result.reachLine, result.tokuzu, result.reachPatternName);
                }
                else
                {
                    reels = Reel.Choose(result.reachLine, result.tokuzu);
                }

                if (result.reachPatternName.Contains("SP"))
                {
                    var startTime = 0f;
                    if (HoryuSu.Value < 3)
                    {
                        startTime = 14f;
                    }
                    else
                    {
                        startTime = 8f;
                    }

                    if (result.reachPatternName.Contains("SP1"))
                    {
                        GinparaManager.Instance.StartCoroutine(SP1Start(startTime, result.reachLine));
                    }
                    else if (result.reachPatternName.Contains("SP2"))
                    {
                        GinparaManager.Instance.StartCoroutine(SP2Start(startTime, result.reachLine));
                    }
                    else if (result.reachPatternName.Contains("SP3"))
                    {
                        GinparaManager.Instance.StartCoroutine(SP3Start(startTime, result.reachLine));
                    }
                }

                // 上段停止
                DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[0].Sizi, 1f);

                // 下段停止
                DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[2].Sizi, 1f, () =>
                {
                    // 下段停止後
                    // リーチ（掛け声）発声
                    AudioManager.Instance.PlaySE(20);

                    if (result.reachPatternName.Contains("SP"))
                    {
                        Effect.Instance.SendEvent("SPリーチ中");
                    }
                    else
                    {
                        Effect.Instance.SendEvent("ノーマルリーチ中");
                    }

                    // リーチライン
                    if (result.reachLine == 4)
                    {
                        AudioManager.Instance.PlayBGMLoop(8);
                    }
                    else
                    {
                        AudioManager.Instance.PlayBGMLoop(5);
                    }

                    if (result.reachPatternName.Contains("泡"))
                    {
                        GinparaManager.Instance.Order("104");
                    }

                    if (result.reachPatternName.Contains("魚群"))
                    {
                        GinparaManager.Instance.Order("105");
                    }
                });

                // 中段停止
                DirectionController.GetComponent<ReelController>().EnqueueDirection(reels[1].Sizi, 1f, () =>
                {
                    // 中段停止後
                    if (result.reachPatternName.Contains("SP1"))
                    {
                        SP1Stop(result.reachLine, KenriKaisu.Value);
                    }
                    else if (result.reachPatternName.Contains("SP2"))
                    {
                        SP2Stop(result.reachLine);
                    }
                    else if (result.reachPatternName.Contains("SP3"))
                    {
                        SP3Stop(result.reachLine);
                    }

                    // 停止音
                    AudioManager.Instance.PlaySE(14);
                    AudioManager.Instance.StopBGM();

                    if(result.isOOatari){
                        MarinController.GetComponent<PlayMakerFSM>().SendEvent("Atari");
                        OoatariController.Instance.Ooatari(atariZugara);
                    }
                    else
                    {
                        // SPリーチハズレの場合は背景をスワップ
                        if (result.reachPatternName.Contains("SP"))
                        {
                            BodyDisplay.Instance.Swap();
                        }

                        callback();
                    }
                });
            }

            IsOoatari.Value = result.isOOatari;
            ReachLine.Value = result.reachLine;
            ReachPattern.Value = result.reachPattern;

		    Finish();
	    }

        IEnumerator SP1Start(float time, int ReachLine)
        {
            var count = 0f;
            while (count < time)
            {
                count += Time.deltaTime;
                yield return null;
            }

            var se = 9; // SリーチSP
            AudioManager.Instance.PlayBGMLoop(se);

            // SPリーチで紫にしない
            //GinparaManager.Instance.Order("102");
            GinparaManager.Instance.Order("901");

            yield return null;

        }

        IEnumerator SP2Start(float time, int ReachLine)
        {
            var count = 0f;
            while (count < time)
            {
                count += Time.deltaTime;
                yield return null;
            }

            var se = 9; // SリーチSP
            AudioManager.Instance.PlayBGMLoop(se);

            switch(ReachLine){
                case 1:
                    GinparaManager.Instance.Order("106-1");
                    break;
                case 2:
                    GinparaManager.Instance.Order("106-3");
                    break;
                case 3:
                    GinparaManager.Instance.Order("106-5");
                    break;
                case 4:
                    GinparaManager.Instance.Order("106-3");
                    break;
            }

            yield return null;
        }

        IEnumerator SP3Start(float time, int ReachLine)
        {
            var count = 0f;
            while (count < time)
            {
                count += Time.deltaTime;
                yield return null;
            }

            var se = 10; // WリーチSP
            AudioManager.Instance.PlayBGMLoop(se);

            MarinController.GetComponent<PlayMakerFSM>().SendEvent("Display");

            yield return null;
        }

        void SP1Stop(int ReachLine, int KenriKaisu)
        {
            if (KenriKaisu == 0)
            {
                GinparaManager.Instance.Order("101");
            }
            else
            {
                GinparaManager.Instance.Order("103");
            }
        }

        void SP2Stop(int ReachLine)
        {
            switch (ReachLine)
            {
                case 1:
                    GinparaManager.Instance.Order("106-2");
                    break;
                case 2:
                    GinparaManager.Instance.Order("106-4");
                    break;
                case 3:
                    GinparaManager.Instance.Order("106-6");
                    break;
                case 4:
                    GinparaManager.Instance.Order("106-2");
                    break;
            }
        }

        void SP3Stop(int ReachLine)
        {
            MarinController.GetComponent<PlayMakerFSM>().SendEvent("Out");
        }
    }

}
