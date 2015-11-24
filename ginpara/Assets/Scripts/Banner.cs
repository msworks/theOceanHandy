using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Banner : MonoBehaviour
{

    public List<string> spriteNames;

    public float span = 2.0f;

    void Start()
    {
        StartCoroutine(anim());
    }

    private IEnumerator anim()
    {
        var sprite = GetComponent<UISprite>();

        foreach (var spriteName in new CycleSequence2<string>(spriteNames))
        {
            yield return new WaitForSeconds(span);
            sprite.spriteName = spriteName;
        }
    }

}

public class CycleSequence2<T> : IEnumerable<T>
{
    protected List<T> list;

    public CycleSequence2(List<T> reel) { list = reel; }

    public IEnumerator<T> GetEnumerator()
    {
        while (true)
        {
            foreach (T rl in list)
            {
                yield return rl;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
