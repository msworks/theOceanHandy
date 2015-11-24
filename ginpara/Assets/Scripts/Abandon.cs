using UnityEngine;
using System.Collections;

/// <summary>
/// 玉を消す
/// </summary>
public class Abandon : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
