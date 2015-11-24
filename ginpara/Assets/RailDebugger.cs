using UnityEngine;
using System.Collections;

public class RailDebugger : MonoBehaviour
{
    [SerializeField]
    Rail[] rails;

	void Start ()
    {
	    
	}

	void Update ()
    {
	    if( rails[0].IsAnimating && !rails[2].IsAnimating )
        {
            //Debug.Log("上だけ動いてる");
        }
	}
}
