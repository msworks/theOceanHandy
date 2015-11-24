using UnityEngine;
using System.Collections;

/// <summary>
/// 告知クラス
/// </summary>
public class Kokuti : MonoBehaviour {

    private static Kokuti _instance;

    UISprite flash;

    bool state = false;

    public static Kokuti Instance { get { return _instance; } }

    void Start()
    {
        _instance = this;
        flash = GetComponent<UISprite>();
        flash.alpha = 0.0f;
    }

    public void KokutiActionA()
    {
        state = true;
        StartCoroutine(enumKokutiActionA());
    }

    public void Finish()
    {
        state = false;
    }

    private IEnumerator enumKokutiActionA()
    {
        yield return new WaitForSeconds(1f);

        AudioManager.Instance.PlaySE(21, 0.2f);

        var count = 0f;
        var alpha = 0f;
        flash.alpha = alpha;

        while (state==true)
        {
            alpha = Mathf.Abs(Mathf.Sin(count * 30)*Mathf.Sin(count*30)*3);
            flash.alpha = alpha;
            count += Time.deltaTime;
            yield return null;
        }

        flash.alpha = 0f;
    }

}
