using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class LightButton : FsmStateAction
{
    public UISprite LightObject;

	public override void OnEnter()
	{
        GinparaManager.Instance.StartCoroutine(light());

        Finish();
    }

    IEnumerator light()
    {
        var totalTime = 0.5f;
        var count = 0.0f;
        LightObject.alpha = 1.0f;

        while (count < totalTime)
        {
            count += Time.deltaTime;
            LightObject.alpha = 1.0f - count / totalTime;
            yield return null;
        }

        LightObject.alpha = 0.0f;

        yield return null;
    }
}
