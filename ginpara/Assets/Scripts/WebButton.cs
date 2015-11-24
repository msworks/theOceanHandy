using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ウェブボタン
/// </summary>
public class WebButton : MonoBehaviour {

    public UISprite lightButton;
    public GameObject CloseButton;

    [SerializeField]
    GameObject WebMenu;

    [SerializeField]
    List<GameObject> DisplayPanels;

    [SerializeField]
    List<GameObject> HidePanels;

    void Start()
    {
        StartCoroutine(light());
    }

    /// <summary>
    /// タップ時処理
    /// </summary>
    public void OnClick()
    {
        // 盤面に玉がある場合はメニュー表示しない
        if (Ball.Count != 0)
        {
            // バルーン表示
            Balloon.Instance.Display();
            return;
        }

        StartCoroutine(light());

        WebMenu.SetActive(true);

        foreach(var panel in DisplayPanels)
        {
            panel.SetActive(true);
        }

        foreach (var panel in HidePanels)
        {
            panel.SetActive(false);
        }
    }

    IEnumerator light()
    {
        var totalTime = 0.5f;
        var count = 0.0f;
        lightButton.alpha = 1.0f;

        while (count < totalTime)
        {
            count += Time.deltaTime;
            lightButton.alpha = 1.0f - count / totalTime;
            yield return null;
        }

        lightButton.alpha = 0.0f;

        yield return null;
    }

}
