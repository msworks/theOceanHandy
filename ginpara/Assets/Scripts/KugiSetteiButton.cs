using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class KugiSetteiButton : MonoBehaviour
{

    [SerializeField]
    int Kugi;

    [SerializeField]
    UISprite[] buttons;

    Dictionary<bool, string> spriteNameMap = new Dictionary<bool, string>()
    {
        { true, "level_num_g_01" },
        { false, "level_num_r_01" },
    };

    public void OnClick()
    {
        buttons.ToList().ForEach(button =>
        {
            button.spriteName = spriteNameMap[false];
        });

        GetComponent<UISprite>().spriteName = spriteNameMap[true];

        var Settings = new List<SettingValue>(){
            SettingValue.設定1,
            SettingValue.設定2,
            SettingValue.設定3,
            SettingValue.設定4,
            SettingValue.設定5,
            SettingValue.設定6,
        };

        KugiSettei.Instance.SetSettei(Settings[Kugi-1]);
    }

}
