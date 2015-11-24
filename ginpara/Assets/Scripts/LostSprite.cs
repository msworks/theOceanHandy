using UnityEngine;
using System.Collections;

public class LostSprite : MonoBehaviour {

    static LostSprite _instance;
    static public LostSprite Instance { get { return _instance; } }

    UISprite sprite;

    void Start()
    {
        _instance = this;
        sprite = GetComponent<UISprite>();
        this.Hide();
    }

    public LostSprite Show()
    {
        sprite.alpha = 1.0f;
        return this;
    }

    public LostSprite Hide()
    {
        sprite.alpha = 0.0f;
        return this;
    }
}
