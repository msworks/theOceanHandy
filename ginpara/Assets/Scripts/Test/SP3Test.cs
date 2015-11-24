using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ginpara;

public class SP3Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Debug.Log("Pushed");

        NotOoatariTestSP3(4, 1);
    }

    public void NotOoatariTestSP3(
        int ReachLine,
        int Tokuzu
    )
    {
        //for (int i = 0; i < 100; i++)
        {

            var reels = Reel.ChooseSP(ReachLine, Tokuzu, "泡＋SP3");

            if (IsOoatari(reels))
            {
                Debug.Log("当たってしまった");
            }
        }

    }


    /// <summary>
    /// 大当たりしているか調査
    /// </summary>
    /// <param name="reels"></param>
    /// <returns></returns>
    public bool IsOoatari(ReelElement[] reels)
    {
        var cr1 = Ginpara.Reel.CyclicReel1;
        var cr2 = Ginpara.Reel.CyclicReel2;
        var cr3 = Ginpara.Reel.CyclicReel3;

        var cr2List = new List<CycleSequence<ReelElement>>() {
            Ginpara.Reel.CyclicReel2,
            Ginpara.Reel.CyclicReel2SP_RIGHT,
            Ginpara.Reel.CyclicReel2SP_CENTER,
            Ginpara.Reel.CyclicReel2SP_LEFT
        };

        foreach (var cr2e in cr2List)
        {
            if (cr2e.Contains(reels[1]))
            {
                cr2 = cr2e;
            }
        }

        var r1 = cr1.SkipWhile(elem => !elem.Sizi.Equals(reels[0].Sizi))
                    .Take(3).ToArray();
        var r2 = cr2.SkipWhile(elem => !elem.Sizi.Equals(reels[1].Sizi))
                    .Take(3).ToArray();
        var r3 = cr3.SkipWhile(elem => !elem.Sizi.Equals(reels[2].Sizi))
                    .Take(3).ToArray();

        var line1 = new string[] { r1[0].Tokuzu, r2[0].Tokuzu, r3[0].Tokuzu };
        var line2 = new string[] { r1[1].Tokuzu, r2[1].Tokuzu, r3[1].Tokuzu };
        var line3 = new string[] { r1[2].Tokuzu, r2[2].Tokuzu, r3[2].Tokuzu };
        var line41 = new string[] { r1[0].Tokuzu, r2[1].Tokuzu, r3[2].Tokuzu };
        var line42 = new string[] { r1[2].Tokuzu, r2[1].Tokuzu, r3[0].Tokuzu };

        var lines = new List<string[]> { line1, line2, line3, line41, line42 };

        var result = false;

        lines.ForEach(line =>
        {
            if (line[0].Equals(line[1]) && line[1].Equals(line[2]))
            {
                if (!line[0].Equals("*"))
                {
                    result = true;
                }
            }
        });

        return result;
    }
}
