using UnityEngine;
using System.Collections;

/// <summary>
/// ディスプレイボタン
/// </summary>
public class DisplayButton : MonoBehaviour {

    // イベント
    private string msg = "change";

    public void OnClick()
    {
        this.gameObject.GetComponent<PlayMakerFSM>().SendEvent(msg);
    }

}
