using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AtariZugara : MonoBehaviour {

    /// <summary>
    /// 図柄１～１０
    /// </summary>
    public enum Kind
    {
        z1,
        z2,
        z3,
        z4,
        z5,
        z6,
        z7,
        z8,
        z9,
        z10
    }

    static AtariZugara _instance;

    public static AtariZugara Instance { get { return _instance; } }

    [SerializeField]
    private UISprite Zugara;

    [SerializeField]
    private List<UISprite> elements;

    public AtariZugara Display(Kind kind)
    {
        Zugara.spriteName = kind2SpriteName[kind];
        elements.ForEach(e => e.alpha = 1.0f);
        return this;
    }

    public AtariZugara Hide()
    {
        elements.ForEach(e => e.alpha = 0.0f);
        return this;
    }

    Dictionary<Kind, string> kind2SpriteName;

	void Start () {
        _instance = this;
        kind2SpriteName = new Dictionary<Kind, string>(){
            { Kind.z1, "1_a" },
            { Kind.z2, "2_a" },
            { Kind.z3, "3_a" },
            { Kind.z4, "4_a" },
            { Kind.z5, "5_a" },
            { Kind.z6, "6_a" },
            { Kind.z7, "7_a" },
            { Kind.z8, "8_a" },
            { Kind.z9, "9_a" },
            { Kind.z10, "10_a" },
        };

        Hide();
	}
	
}
