using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchScreen : MonoBehaviour {

    // インスペクタから設定する
    public Camera secondCamera;

    // on:拡大中
    // off:通常表示中
    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        secondCamera.gameObject.SetActive(false);
    }

	public void OnValueChange(bool value)
    {
        if (value == true)
        {
            secondCamera.orthographicSize = 0.17f;
            secondCamera.gameObject.SetActive(true);
        }
        else
        {
            secondCamera.orthographicSize = 0.3f;
            secondCamera.gameObject.SetActive(false);
        }
    }

}
