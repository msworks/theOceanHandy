using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �X���C�_�[�̒l���擾����
/// </summary>
[ActionCategory("Ginpara")]
public class GetSliderValue : FsmStateAction
{
    public GameObject Slider;
    public FsmFloat   Value;
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
        Value.Value = Slider.GetComponent<UISlider>().value;
		Finish();
	}


}
