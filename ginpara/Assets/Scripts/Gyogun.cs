using UnityEngine;
using System.Collections;

public class Gyogun : MonoBehaviour {

    static Gyogun _instance;
    static public Gyogun Instance { get { return _instance; } }

    void Start()
    {
        _instance = this;
    }

    public Gyogun Flow()
    {
        GetComponent<Animator>().SetTrigger("Start");

        return this;
    }

}
