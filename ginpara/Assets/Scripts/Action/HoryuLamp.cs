using UnityEngine;
using HutongGames.PlayMaker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// �ۗ������v��num�̐���������
/// </summary>
[ActionCategory("Ginpara")]
public class HoryuLamp : FsmStateAction
{
    public GameObject[] Lamps;
    public FsmInt num;
	
    /// <summary>
    /// �J�ڎ��̏���
    /// </summary>
	public override void OnEnter()
	{
        // �_��
        Lamps.ToList().Take(num.Value).ToList().ForEach(lamp=>{
            lamp.GetComponent<UISprite>().alpha = 1;
        });

        // ����
        Lamps.ToList().Skip(num.Value).ToList().ForEach(lamp =>
        {
            lamp.GetComponent<UISprite>().alpha = 0f;
        });

        Finish();
	}


}
