using UnityEngine;
using System.Collections;

public class SliderChange : MonoBehaviour {

    static SliderChange _instance;
    static public SliderChange Instance { get { return _instance; } }

    [SerializeField]
    private UILabel number;

	void Start () {
        _instance = this;
	}

    public int value { set; get; }

    public void OnValueChanged(float value)
    {
        var v = (int)(value * 10);
        number.text = v.ToString();
        this.value = v;
    }
}
