using UnityEngine;
using System.Collections;

public class ToggleHandle : MonoBehaviour {

    const string message = "TapHandle";

    public void OnClick()
    {
        this.gameObject.GetComponent<PlayMakerFSM>().SendEvent(message);
    }
}
