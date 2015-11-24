using UnityEngine;
using System.Collections;

/// <summary>
/// データボタン
/// </summary>
public class DataButton : MonoBehaviour {

    // イベント
    private string msg = "change";

    /// <summary>
    /// タップ時処理
    /// </summary>
    public void OnClick()
    {
        this.gameObject.GetComponent<PlayMakerFSM>().SendEvent(msg);
    }

}
