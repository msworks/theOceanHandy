using UnityEngine;
using System.Collections;

// 回転体に玉が乗ったときの挙動
// ボールの状態を変化させる。自律的にやる。
// 
public class TouchKaitentai : MonoBehaviour {

    public GameObject TurnBallPrefab;
    public GameObject BodyPath;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        this.gameObject.GetComponent<PlayMakerFSM>().SendEvent("玉通過");
    }

}
