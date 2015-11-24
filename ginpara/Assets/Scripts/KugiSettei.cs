using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;


public enum SettingValue
{
    設定1,
    設定2,
    設定3,
    設定4,
    設定5,
    設定6,
}

public class KugiSettei : MonoBehaviour {

    [SerializeField]
    Text UI;

    [SerializeField]
    Transform[] kugis;

    static KugiSettei _instance;
    static public KugiSettei Instance { get { return _instance; } }

    // 釘の元の位置
    Vector3[] kugiOrigin;

    /// <summary>
    /// int[] には, A～Xまでの釘の設定が入る
    /// 設定値は0～４
    /// 0:移動しない
    /// 1:上に半釘
    /// 2:右に半釘
    /// 3:下に半釘
    /// 4:左に半釘
    /// </summary>
    Dictionary<SettingValue, int[]> Settings = new Dictionary<SettingValue, int[]>();

    void Start()
    {
        _instance = this;

        // 設定ファイルを読み込む
        try
        {
#if UNITY_ANDROID || UNITY_WEBPLAYER || UNITY_IOS
            // 設定ファイルを読み込む
            TextAsset textAsset = Resources.Load("KugiConfig", typeof(TextAsset)) as TextAsset;
            var textReader = new StringReader(textAsset.text);
#endif

#if UNITY_STANDALONE
            var textReader = new StreamReader("KugiConfig.txt");
#endif
            var lines = new List<int>();
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                int a;

                if (line.Equals("{ value = 1 }"))
                {
                    a = 1;
                }
                else if (line.Equals("{ value = 2 }"))
                {
                    a = 2;
                }
                else if (line.Equals("{ value = 3 }"))
                {
                    a = 3;
                }
                else if (line.Equals("{ value = 4 }"))
                {
                    a = 4;
                }
                else if (line.Equals("{ value = 5 }"))
                {
                    a = 5;
                }
                else if (line.Equals("{ value = 6 }"))
                {
                    a = 6;
                }
                else { a = 0; }
                lines.Add(a);
            }
            textReader.Close();

            UI.text = "KugiConfig.txtを読み込みました";

            var itiran = new List<SettingValue>(){
                SettingValue.設定1,
                SettingValue.設定2,
                SettingValue.設定3,
                SettingValue.設定4,
                SettingValue.設定5,
                SettingValue.設定6,
            };

            var chunks = lines.Chunk(28).ToArray();

            // 設定と設定の内容をひもづける
            var settings = itiran.Select((settei, index) => new { settei, chunk = chunks[index].ToArray() });

            // 読み込んだ内容を保持する
            foreach(var s in settings){
                Settings.Add(s.settei, s.chunk);
            }
        }
        catch (Exception)
        {
            UI.text = "KugiConfig.txtが読み込めませんでした";
        }

        // 釘の元の位置をストアしておく
        kugiOrigin = kugis.Select(kugi => {
                if( kugi == null ) { return Vector3.zero; }
                return kugi.transform.position;
            }
        ).ToArray();

        foreach (var kp in kugiOrigin)
        {
            //Debug.Log(kp);
        }

        _instance = this;
        SetSettei(SettingValue.設定1);
    }

    /// <summary>
    /// 釘設定
    /// </summary>
    /// <param name="settei">設定値</param>
    /// <returns></returns>
    public KugiSettei SetSettei(SettingValue settei)
    {
        var chunk = Settings[settei];

        // 釘と設定値をひもづける
        var KugiSettei = kugis.Select((kugi, index) => 
            new { kugi, settei = chunk[index], org=kugiOrigin[index] });

        var d = 0.005f;

        var delta = new Vector3[] {
            new Vector3( 0,  0, 0 ),
            new Vector3( 0,  d, 0 ),
            new Vector3( d,  0, 0 ),
            new Vector3( 0, -d, 0 ),
            new Vector3(-d,  0, 0 ),
            new Vector3( d+d,  0, 0 ),
            new Vector3(-d-d,  0, 0 ),
        };

        foreach (var k in KugiSettei)
        {
            if (k.kugi == null) continue;
            var pos = k.org + delta[k.settei];
            k.kugi.position = pos;
        }

        return this;
    }
}

public static class ChunkExtensions
{
    /// <summary>
    /// シーケンスを指定されたサイズのチャンクに分割します.
    /// </summary>
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> self, int chunkSize)
    {
        if (chunkSize <= 0)
        {
            throw new ArgumentException("Chunk size must be greater than 0.", "chunkSize");
        }

        while (self.Any())
        {
            yield return self.Take(chunkSize);
            self = self.Skip(chunkSize);
        }
    }
}

