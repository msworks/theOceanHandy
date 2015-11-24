using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public Transform LB;
    public Transform RT;

    static Background _instance;
    static public Background Instance { get { return _instance; } }

	void Start () {
        _instance = this;
        StartCoroutine(scroll());
	}

    /// <summary>
    /// 横スクロール
    /// </summary>
    /// <returns></returns>
    IEnumerator scroll()
    {
        float originX = transform.position.x;
        float delta = 0.001f;

        while (true)
        {
            var pos = transform.position;
            pos.x += delta;
            if (pos.x > RT.position.x)
            {
                pos.x = originX;
            }

            transform.position = pos;

            yield return new WaitForSeconds(0.05f);
        }
    }

    public Background up()
    {
        var hash = iTween.Hash(
            "y", RT.position.y,
            "time", 6.0f
        );

        iTween.MoveTo(this.gameObject, hash);

        return this;
    }

    public Background down()
    {
        var hash = iTween.Hash(
            "y", LB.position.y,
            "time", 6.0f
        );

        iTween.MoveTo(this.gameObject, hash);

        return this;
    }

    public Background ChangeTexture(Texture texture)
    {
        GetComponent<UITexture>().mainTexture = texture;
        return this;
    }
}
