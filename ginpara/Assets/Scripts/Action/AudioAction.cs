using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ActionCategory("Ginpara")]
public class PlayBGMOneShot : FsmStateAction
{
    public FsmInt index;

	public override void OnEnter()
	{
        AudioManager.Instance.PlayBGMOneShot(index.Value);

        Finish();
    }
}

[ActionCategory("Ginpara")]
public class PlayBGMLoop : FsmStateAction
{
    public FsmInt index;

    public override void OnEnter()
    {
        AudioManager.Instance.PlayBGMLoop(index.Value);

        Finish();
    }
}

[ActionCategory("Ginpara")]
public class PlaySE : FsmStateAction
{
    public FsmInt index;

    public override void OnEnter()
    {
        AudioManager.Instance.PlaySE(index.Value);

        Finish();
    }
}

[ActionCategory("Ginpara")]
public class PlayHoryuon : FsmStateAction
{
    public FsmInt HoryuCount;
    public FsmInt SoundNo;

    public override void OnEnter()
    {
        if (HoryuCount.Value <= 4)
        {
            AudioManager.Instance.PlaySE(SoundNo.Value);
        }

        Finish();
    }
}
