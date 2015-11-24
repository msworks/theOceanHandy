using UnityEngine;
using System.Collections;

public class TapTest : MonoBehaviour {

    public void OnClick()
    {
        this.GetComponent<PlayMakerFSM>().SendEvent("Tap");
    }

}
