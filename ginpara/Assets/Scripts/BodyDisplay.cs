using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BodyDisplay : MonoBehaviour {

    static BodyDisplay _instance;

    public static BodyDisplay Instance { get { return _instance; } }

    UISprite sprite;

	void Start () {
        _instance = this;
        sprite = this.GetComponent<UISprite>();
	}

	public void Swap()
    {
        var list = new List<string>(){
            "back1",
            "back2",
        };

        if(sprite.spriteName.Equals(list.First()))
        {
            sprite.spriteName = list.Last();
        }
        else
        {
            sprite.spriteName = list.First();
        }
    }
}
