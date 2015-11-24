using UnityEngine;
using System.Collections;

/// <summary>
/// 抽選結果構造体
/// </summary>
public struct DrawLotResult {

    public bool isOOatari;          // true:大当たり false:はずれ
    public int reachLine;           // リーチライン
    public int reachPattern;        // リーチパターン 
    public string reachLineName;    // リーチライン名
    public string reachPatternName; // リーチパターン名
    public int tokuzu;              // 特図

}
