using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ラウンド表示
/// </summary>
public class RoundDisplay : MonoBehaviour {

    static RoundDisplay _instance;

    static public RoundDisplay Instance { get { return _instance; } }

    /// <summary>
    /// ０～９の数字のテクスチャ
    /// </summary>
    public Texture[] Numbers;

    /// <summary>
    /// ∀の要素
    /// </summary>
    public List<UITexture> items;

    /// <summary>
    /// 左辺(/で区切られた左辺)
    /// </summary>
    public List<UITexture> left;

    /// <summary>
    /// 数字を表示
    /// </summary>
    /// <param name="number">現在のラウンド数</param>
    public void display(int number)
    {
        on();

        var textures = string.Format("{0:00}", number)
                             .ToCharArray().ToList()
                             .Select(c => int.Parse(c.ToString()))
                             .Select(n => Numbers[n])
                             .ToArray();

        var set = from l in left
                  from t in textures
                  select new { l, t };

        // Zipがない

        var count = 0;

        foreach (var uiTexture in left)
        {
            uiTexture.mainTexture = textures[count];
            count++;
        }
    }

    public void hide()
    {
        off();
    }

	void Start () {
        _instance = this;
        off();
	}

    void on()
    {
        items.ForEach(texture => texture.alpha = 1.0f);
    }

    void off()
    {
        items.ForEach(texture => texture.alpha = 0f);
    }
}
