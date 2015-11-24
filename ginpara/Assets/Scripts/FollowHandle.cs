using UnityEngine;
using System.Collections;

public class FollowHandle : MonoBehaviour {

    public GameObject Handle;

    public void OnValueChanged()
    {
        var value = this.gameObject.GetComponent<UISlider>().value;

        value *= -60.0f;

        Handle.GetComponent<PlayMakerFSM>().FsmVariables.GetFsmFloat("Rotation").Value = value;
        Handle.GetComponent<PlayMakerFSM>().SendEvent("Rotation");
    }

}
