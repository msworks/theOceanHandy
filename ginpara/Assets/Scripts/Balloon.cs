using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour
{
    static Balloon _instance;
    static public Balloon Instance { get { return _instance; } }

	void Start ()
    {
        _instance = this;
        //StartCoroutine(AnimationCore());
        var uiSprite = GetComponent<UISprite>();
        uiSprite.alpha = 0.0f;
	}
	
    public Balloon Display()
    {
        StartCoroutine(AnimationCore());
        return this;
    }

    IEnumerator AnimationCore()
    {
        var uiSprite = GetComponent<UISprite>();
        var time = 0.0f;
        var displayTime = 0.5f;

        while(time < displayTime)
        {
            time += Time.deltaTime;
            uiSprite.alpha = 1.0f;
            yield return null;
        }

        uiSprite.alpha = 0.0f;
    }

}
