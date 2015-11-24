using HutongGames.PlayMaker;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// アベレージを表示する
/// 仕様：総回転数÷大当り回数
/// </summary>
public class Average : MonoBehaviour {

    static Average _instance;
    static public Average Instance { get { return _instance; } }

    [SerializeField]
    List<UISprite> numbers;

    string[] numberSpriteNames;

    void Start()
    {
        _instance = this;

        numberSpriteNames = new string[]
        {
            "seg_34px_g_00",    // 0
            "seg_34px_g_01",    // 1
            "seg_34px_g_02",    // 2
            "seg_34px_g_03",    // 3
            "seg_34px_g_04",    // 4
            "seg_34px_g_05",    // 5
            "seg_34px_g_06",    // 6
            "seg_34px_g_07",    // 7
            "seg_34px_g_08",    // 8
            "seg_34px_g_09",    // 9
        };
    }

    /// <summary>
    /// アベレージを表示
    /// </summary>
    /// <param name="souKaitensu">総回転数</param>
    /// <param name="ooatariKaisu">大当り回数</param>
    public void Display(int souKaitensu, int ooatariKaisu)
    {
        if (ooatariKaisu == 0) ooatariKaisu = 1;

        var floatAverage = (float)souKaitensu / (float)ooatariKaisu;
        var intAverage = (int)floatAverage;

        Debug.Log("総回転数："+souKaitensu);
        Debug.Log("大当り回数:"+ooatariKaisu);

        intAverage = intAverage.Clamp(0, 9999);

        // アベレージを４桁のスプライト名の配列にする
        // 最初の要素は１桁目
        var numberNameArray = string.Format("{0:0000}",intAverage)  // 0123
                                    .ToCharArray()                  // 0, 1, 2, 3
                                    .Reverse()                      // 3, 2, 1, 0
                                    .Select(c => int.Parse(c.ToString()))   // (int)3, 2, 1, 0
                                    .Select(i => numberSpriteNames[i])      // seg...
                                    .ToArray();

        // numberArrayとnumbers(スプライト）の組を作る
        var ns = Enumerable.Range(0, 4);
        var numberTag = ns.Select(n=>new { numberSprite=numbers[n], numberName=numberNameArray[n]})
                          .ToList();

        // 各数値を反映
        numberTag.ForEach(nt =>
        {
            nt.numberSprite.spriteName = nt.numberName;
        });
    }

    [ActionCategory("Ginpara")]
    public class Update : FsmStateAction
    {
        public FsmInt SouKaitensu;
        public FsmInt OoatariKaisu;

        public override void OnEnter()
        {
            Average.Instance.Display(SouKaitensu.Value, OoatariKaisu.Value);
            Finish();
        }
    }
}

static class intEx
{
    /// <summary>
    /// 整数を指定の範囲にクランプする
    /// </summary>
    /// <param name="number">対象の数値</param>
    /// <param name="max">最大値</param>
    /// <param name="min">最小値</param>
    /// <returns>クランプされた整数</returns>
    public static int Clamp(this int number, int min, int max)
    {
        if (max < number)
        {
            number = max;
        }
        else if (number < min)
        {
            number = min;
        }

        return number;
    }
}
