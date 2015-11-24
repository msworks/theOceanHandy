using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BataashiMarin : MonoBehaviour {

    static BataashiMarin _instance;
    public List<Texture> textureList;

    float Span = 0.05f;

    void Start()
    {
        _instance = this;
        StartCoroutine(anim());
    }

    static public BataashiMarin Instance { get { return _instance; } }

    public BataashiMarin Display()
    {
        var image = GetComponent<UITexture>();
        image.alpha = 1.0f;
        return this;
    }

    public BataashiMarin Hide()
    {
        var image = GetComponent<UITexture>();
        image.alpha = 0f;
        return this;
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
}

public static class EnumerableEx
{
    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source)
    {
        while (true)
        {
            foreach (var item in source)
            {
                yield return item;
            }
        }
    }
}
