using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MarinLose : MonoBehaviour {

    static MarinLose _instance;
    public List<Texture> textureList;

    UITexture uiTexture;
    float Span = 0.05f;
    static public MarinLose Instance { get { return _instance; } }

	void Start () {
        _instance = this;
        uiTexture = GetComponent<UITexture>();
        Hide();
        StartCoroutine(anim());
	}

    IEnumerator anim()
    {
        var image = GetComponent<UITexture>();

        var reverseList = textureList.Reverse<Texture>().Skip(1).ToList();
        var textureList2 = textureList.Concat(reverseList);

        foreach (var texture in textureList2.Repeat())
        {
            yield return new WaitForSeconds(Span);
            image.mainTexture = texture;
        }
    }

    public MarinLose Display()
    {
        uiTexture.alpha = 1.0f;
        return this;
    }

    public MarinLose Hide()
    {
        uiTexture.alpha = 0.0f;
        return this;
    }
}
