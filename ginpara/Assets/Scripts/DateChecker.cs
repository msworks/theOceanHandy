using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 日付チェッカー もとい締め処理
/// </summary>
public class DateChecker : MonoBehaviour {

    // 締めで持ち越すデータ群

    static private DateChecker _instance;

    static public DateChecker Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (!_instance)
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);

            // 再開処理
            LoadData();
        }
    }

    static DateTime start = DateTime.Now;

	void Start () {
        StartCoroutine(Check());
	}

    /// <summary>
    /// 日付を監視し、日付が変わったら回転数を入れ替える
    /// </summary>
    /// <returns></returns>
    IEnumerator Check()
    {
        while (true)
        {
            var time = DateTime.Now;
            var day = time.Day;
            var startDay = start.Day;

            if (day != startDay)
            {
                start = DateTime.Now;
                CasinoData.Instance.ShiftKaitensu();

                // データ保管
                SaveData();

                // 締め処理
                Application.LoadLevel("ginpara");
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    static private int[] history;
    static private int preBB;
    static private int prepreBB;
    static private int preRB;
    static private int prepreRB;

    private void SaveData()
    {
        history = History.Instance.Data;
        preBB = CasinoData.Instance.PreBB;
        prepreBB = CasinoData.Instance.PrePreBB;
        preRB = CasinoData.Instance.PreRB;
        prepreRB = CasinoData.Instance.PrePreRB;
    }

    private void LoadData()
    {
        History.Instance.Data = history;
        History.Instance.DisplayGameRound();
        CasinoData.Instance.BB = prepreBB;
        CasinoData.Instance.RB = prepreRB;
        CasinoData.Instance.ShiftKaitensu();
        CasinoData.Instance.BB = preBB;
        CasinoData.Instance.RB = preRB;
        CasinoData.Instance.ShiftKaitensu();
    }

    /// <summary>
    /// 開始日付更新(デバッグ用)
    /// </summary>
    /// <param name="dt"></param>
    public void SetStartDate(DateTime dt)
    {
        start = dt;
    }

    /// <summary>
    /// 前日をセットする
    /// </summary>
    [ActionCategory("Ginpara")]
    public class SetPreDate : FsmStateAction
    {
        public override void OnEnter()
        {
            var dt = DateTime.Now;
            var predt = dt.AddDays(-1);
            DateChecker.Instance.SetStartDate(predt);
            Finish();
        }
    }
}
