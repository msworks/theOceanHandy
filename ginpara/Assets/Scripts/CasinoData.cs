using HutongGames.PlayMaker;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// </summary>
public class CasinoData : MonoBehaviour {

    string[,] sevenSegSpriteName = new string[,]{
        {"7segR0", "7segR1", "7segR2", "7segR3", "7segR4", "7segR5", "7segR6", "7segR7", "7segR8", "7segR9", "7segNone"},
        {"7segO0", "7segO1", "7segO2", "7segO3", "7segO4", "7segO5", "7segO6", "7segO7", "7segO8", "7segO9", "7segNone"},
        {
            "seg_34px_g_00",
            "seg_34px_g_01",
            "seg_34px_g_02",
            "seg_34px_g_03",
            "seg_34px_g_04",
            "seg_34px_g_05",
            "seg_34px_g_06",
            "seg_34px_g_07",
            "seg_34px_g_08",
            "seg_34px_g_09",
            "seg_34px_g_blank",
        },
    };
    
    [SerializeField]
    UISprite[] gameCounterSprites = null;

    int gameCount = 0;
    enum AVG_STATE
    {
        BB,
        RB,
        ATART
    }
     AVG_STATE avgState = AVG_STATE.BB;
    [SerializeField] UISprite onePerLabel = null;
    string[] onePerSpriteName = new string[]{"1perR", "1perO", "1perG"};
    [SerializeField]
    UISprite[] avgSprites = null;
    int avg = 0;
    [SerializeField]
    UISprite exchangeMark = null;
    public enum EXCHANGE
    {
        yen,
        gen,
        euro,
        dl
    }
    EXCHANGE exchange;
    [SerializeField]
    UISprite[] exchangeSprites = null;

    [SerializeField]
    UISprite exchangeDotSprites = null;

    float exchangeNum = 0;

    [SerializeField]
    UISprite[] exchangeRateSprites = null;
    [SerializeField]
    UISprite exchangeRateDotSprites = null;
    float exchangeRateNum = 0;
    [SerializeField]
    UISprite[] bbSprites = null;
    int bbNum = 0;
    [SerializeField]
    UISprite[] rbSprites = null;
    int rbNum = 0;
    [SerializeField]
    UISprite[] atSprites = null;
    int atNum = 0;
    [SerializeField]
    UISprite[] pre1BbSprites = null;
    int pre1BbNum = 0;
    [SerializeField]
    UISprite[] pre2BbSprites = null;
    int pre2BbNum = 0;
    [SerializeField]
    UISprite[] pre1RbSprites = null;
    int pre1RbNum = 0;
    [SerializeField]
    UISprite[] pre2RbSprites = null;
    int pre2RbNum = 0;
    [SerializeField]
    UISprite[] pre1AtSprites = null;
    int pre1AtNum = 0;
    [SerializeField]
    UISprite[] pre2AtSprites = null;
    int pre2AtNum = 0;
    [SerializeField]
    UISprite[] historySprites = null;
    List<int> history = new List<int>();
    string[] historySpriteName = new string[]{"level0", "level1", "level2", "level3", "level4", "level5", "level6", "level7", "level8", "level9"};

    int _SouKaitensu;
    int _OoatariKaisu;

    public int SouKaitensu { get; set; }
    public int OoatariKaisu { get; set; }

    public int PreBB { get { return pre1BbNum; } }
    public int PrePreBB { get { return pre2BbNum; } }
    public int PreRB { get { return pre1RbNum; } }
    public int PrePreRB { get { return pre2RbNum; } }

    /// UI-ゲームカウンターを操作する.4桁を超える数字は9999に置換して表示.
    public int GameCount { get { return this.gameCount; } set { this.gameCount = (value > 9999) ? 9999 : value; this.UpdateGameCounter(); } }
    
    /// UI-AVGを操作する.4桁を超える数字は9999に置換して表示.
    public int AVG { get { return this.avg; } set { this.avg = (value > 9999) ? 9999 : value; this.UpdateAVG(); } }
    
    /// UI-BBを操作する.3桁を超える数字は999に置換して表示.
    public int BB { get { return this.bbNum; } set { this.bbNum = (value > 999) ? 999 : value; this.UpdateBB(); } }
    
    /// UI-RBを操作する.3桁を超える数字は999に置換して表示.
    public int RB { get { return this.rbNum; } set { this.rbNum = (value > 999) ? 999 : value; this.UpdateRB(); } }
    
    /// UI-Exchangeを操作する.5桁を超える数字は99999に置換し,小数点は第1位のみを表示.
    public float Exchange { get { return this.exchangeNum; } set { this.exchangeNum = (value > 999999.99f) ? 999999.99f : value; this.UpdateExchange(); } }
    
    /// UI-Exchangeを操作する.2桁を超える数字は99に置換し,小数点は第1位のみを表示.
    public float ExchangeRate { get { return this.exchangeRateNum; } set { this.exchangeRateNum = (value > 99.9f) ? 99.9f : value; this.UpdateExchangeRate(); } }

    static private CasinoData _instance;

    static public CasinoData Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        this.UpdateGameCounter();
        this.ChangeExchangeMark(EXCHANGE.dl);
    }

    void UpdateGameCounter()
    {
        string count = string.Empty;
        int digit = this.gameCount.ToString().Length;
        if (digit < 4)
        {
            for(int i = 0; i < (4 - digit); ++i){
                count += "0";
            }
        }
        count += this.gameCount.ToString();
        for (int i = 0; i < 4; ++i)
        {
            if(4 - digit > i)
                this.gameCounterSprites[i].spriteName = this.sevenSegSpriteName[2, 10];
            else
                this.gameCounterSprites[i].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
        }
    }

    void Update1Per()
    {
        this.onePerLabel.spriteName = this.onePerSpriteName [(int)this.avgState];
    }
    
    /// Dataボタン押下時の処理.
    public void PushDataButton()
    {
        if ((int)this.avgState == 2)
            this.avgState = 0;
        else
            ++this.avgState;

        this.Update1Per();
        this.UpdateAVG();
    }
    
    void UpdateAVG()
    {
        string count = string.Empty;
        int digit = this.avg.ToString().Length;
        if (digit < 4)
        {
            for(int i = 0; i < (4 - digit); ++i){
                count += "0";
            }
        }
        count += this.avg.ToString();
        for (int i = 0; i < 4; ++i)
        {
            if(4 - digit > i)
                this.avgSprites[i].spriteName = this.sevenSegSpriteName[(int)this.avgState, 10];
            else
                this.avgSprites[i].spriteName = this.sevenSegSpriteName[(int)this.avgState, int.Parse(count[i].ToString())];
        }
    }

    /// <summary>
    /// 7セグ表示内容を更新
    /// </summary>
    /// <param name="updateSprites"></param>
    /// <param name="num"></param>
    private void Update7Seg(UISprite[] updateSprites, int num)
    {
        var str = string.Format("{0, 3}", num).Reverse();
        var i = 0;
        foreach (var c in str)
        {
            var spriteName = "";
            if (c == ' ')
            {
                spriteName = this.sevenSegSpriteName[2, 10];
            }
            else
            {
                spriteName = this.sevenSegSpriteName[2, int.Parse(c.ToString())];
            }
            updateSprites[i].spriteName = spriteName;

            i++;
        }
    }

    /// <summary>
    /// 大当たり回数
    /// </summary>
    void UpdateBB()
    {
        Update7Seg(bbSprites, bbNum);
    }

    /// <summary>
    /// 確変回数
    /// </summary>
    void UpdateRB()
    {
        Update7Seg(rbSprites, rbNum);
    }
    
    /// <summary>
    /// 回転数をシフト
    /// 今回→前回にシフト、前回→前々回にシフト、今回→クリア
    /// </summary>
    public void ShiftKaitensu()
    {
        pre2BbNum = pre1BbNum;
        pre1BbNum = bbNum;
        bbNum = 0;

        pre2RbNum = pre1RbNum;
        pre1RbNum = rbNum;
        rbNum = 0;

        Update7Seg(bbSprites, bbNum);
        Update7Seg(pre1BbSprites, pre1BbNum);
        Update7Seg(pre2BbSprites, pre2BbNum);

        Update7Seg(rbSprites, rbNum);
        Update7Seg(pre1RbSprites, pre1RbNum);
        Update7Seg(pre2RbSprites, pre2RbNum);
    }
    
    public void ChangeExchangeMark(EXCHANGE exchange)
    {
        this.exchangeMark.spriteName = exchange.ToString();
    }
    
    public void PushDispButton()
    {
        if ((int)this.exchange == 3)
            this.exchange = 0;
        else
            ++this.exchange;

        this.exchangeMark.spriteName = this.exchange.ToString();
    }

    /// <summary>
    /// Exchangeを表示
    /// </summary>
    void UpdateExchange()
    {
        var num = exchangeNum * 100f;
        var intNum = (int)num;
        var str = string.Format("{0, 8}", intNum).Reverse();
        var i = 0;
        foreach (var c in str)
        {
            var spriteName = "";
            if (c == ' ')
            {
                spriteName = this.sevenSegSpriteName[2, 10];
            }
            else
            {
                spriteName = this.sevenSegSpriteName[2, int.Parse(c.ToString())];
            }
            exchangeSprites[i].spriteName = spriteName;

            i++;
        }
    
    }
    
    void UpdateExchangeRate()
    {
        if (this.exchangeRateNum == 0)
        {
            this.exchangeRateSprites [0].spriteName = this.sevenSegSpriteName [2, 10];
            this.exchangeRateSprites [1].spriteName = this.sevenSegSpriteName [2, 10];
            this.exchangeRateSprites [2].spriteName = this.sevenSegSpriteName [2, 10];
            this.exchangeRateDotSprites.color = new Color(1, 1, 1, 0.05f);
        }
        else
        {
            this.exchangeRateDotSprites.color = Color.white;
            if(this.exchangeRateNum < 1){
                this.exchangeRateSprites [0].spriteName = this.sevenSegSpriteName [2, 10];
                this.exchangeRateSprites [1].spriteName = this.sevenSegSpriteName [2, 0];
                this.exchangeRateSprites [2].spriteName = this.sevenSegSpriteName [2, int.Parse(this.exchangeRateNum.ToString()[2].ToString())];
            }else{
                string count = string.Empty;
                bool dot = false;
                foreach(char c in this.exchangeRateNum.ToString()){
                    if(c.ToString() == ".")
                        dot = true;
                }
                int digit = ((int)this.exchangeRateNum).ToString().Length;
                if (digit < 2)
                {
                    for(int i = 0; i < (2 - digit); ++i){
                        count += "0";
                    }
                }
                count += this.exchangeRateNum.ToString();
                if(dot){
                    for (int i = 0; i < 4; ++i)
                    {
                        if(i < 2){
                            if(2 - digit > i)
                                this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, 10];
                            else
                                this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
                        }else if(i == 3){
                            this.exchangeRateSprites[i - 1].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
                        }
                    }
                }else{
                    for (int i = 0; i < 2; ++i)
                    {
                        if(2 - digit > i)
                            this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, 10];
                        else{
                            this.exchangeRateSprites[i].spriteName = this.sevenSegSpriteName[2, int.Parse(count[i].ToString())];
                        }
                    }
                    this.exchangeRateSprites [2].spriteName = this.sevenSegSpriteName [2, 0];
                }
            }
        }
    }

    /// UI-履歴を追加する.
    public void AddHistory (int num)
    {
        if (num > 9)
            this.history.Add(9);
        else
            this.history.Add(num);

        if (this.history.Count > 10)
            this.history.RemoveAt(0);

        for (int i = 0; i < this.history.Count; ++i)
        {
            this.historySprites[i].spriteName = this.historySpriteName[this.history[i]];
        }
    }

    [ActionCategory("Ginpara")]
    public class IncrementOoatariKaisu : FsmStateAction
    {
        public override void OnEnter()
        {
            CasinoData.Instance.OoatariKaisu++;
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class AddSouKaitensu : FsmStateAction
    {
        public override void OnEnter()
        {
            CasinoData.Instance.SouKaitensu += History.Instance.Data[0];
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class GetOoatariKaisu : FsmStateAction
    {
        public FsmInt OoatariKaisu;

        public override void OnEnter()
        {
            OoatariKaisu.Value = CasinoData.Instance.OoatariKaisu;
            Finish();
        }
    }

    [ActionCategory("Ginpara")]
    public class GetSouKaitensu : FsmStateAction
    {
        public FsmInt SouKaitensu;

        public override void OnEnter()
        {
            SouKaitensu.Value = CasinoData.Instance.SouKaitensu;
            Finish();
        }
    }
}
