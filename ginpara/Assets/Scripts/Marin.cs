using UnityEngine;
using System.Collections;

public class Marin : MonoBehaviour
{
    public GameObject Yobikomi;
    public Transform Goal;

    [SerializeField]
    Texture[] animation;

    Vector3 from;
    Vector3 to;

    static Marin _instance;
    static public Marin Instance { get { return _instance; } }

    void Start()
    {
        _instance = this;
        from = Yobikomi.transform.position;
        to = Goal.transform.position;

        StartCoroutine(AnimationCore());
    }

    IEnumerator AnimationCore()
    {
        var uiTexture = Yobikomi.GetComponent<UITexture>();
        foreach (var texture in animation.Repeat())
        {
            uiTexture.mainTexture = texture;
            yield return new WaitForSeconds(0.03f);
        }

        yield return null;
    }

    public void display()
    {
        iTween.MoveTo(Yobikomi, iTween.Hash("y", to.y, "time", 2f));
    }

    public void hide()
    {
        iTween.MoveTo(Yobikomi, iTween.Hash("y", from.y, "time", 2f));
    }
}
