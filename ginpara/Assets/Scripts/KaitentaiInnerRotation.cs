using UnityEngine;
using System.Collections;

/// <summary>
/// 回転体内部の回転処理
/// </summary>
public class KaitentaiInnerRotation : MonoBehaviour {

    private float Hz = 1f / 12f * 3.14f;        // 1/12ヘルツ

	/// <summary>
	/// 更新
	/// </summary>
	void Update () {
        // Z軸中心で回転する
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime * Hz);
	}
}
