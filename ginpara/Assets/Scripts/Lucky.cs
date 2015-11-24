using UnityEngine;
using System.Collections;

public class Lucky : MonoBehaviour {

    static Lucky _instance;
    static public Lucky Instance { get { return _instance; } }

    UISprite sprite;

	void Start () {
        _instance = this;
        sprite = GetComponent<UISprite>();
        this.Hide();
	}

    public Lucky Show()
    {
        sprite.alpha = 1.0f;
        return this;
    }

    public Lucky Hide()
    {
        sprite.alpha = 0.0f;
        return this;
    }
}
