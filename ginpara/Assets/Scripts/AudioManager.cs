using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// オーディオ管理クラス
/// </summary>
public class AudioManager : MonoBehaviour {

    static private AudioManager _instance;

    static public AudioManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (AudioManager)FindObjectOfType(typeof(AudioManager));
            }

            if (!_instance)
            {
                Debug.LogError("AudioManagerをシーンに配置して下さい");
            }

            return _instance;
        }
    }

    private AudioSource BGMsource;
    private AudioSource[] SEsources = new AudioSource[16];

    public AudioClip[] clips;
    public float[] volumes;

    void Awake()
    {
        BGMsource = this.gameObject.AddComponent<AudioSource>();
        BGMsource.loop = true;

        for (int i = 0; i < SEsources.Length; i++)
        {
            SEsources[i] = this.gameObject.AddComponent<AudioSource>();
        }

    }

    private void PlayBGM(int index)
    {
        if (BGMsource.clip == clips[index] && BGMsource.isPlaying == true)
        {
            // 同一音声が再生中であれば何もしない
            return;
        }

        BGMsource.clip = clips[index];
        BGMsource.volume = volumes[index];
        BGMsource.Play();

    }

    public void PlayBGMLoop(int index)
    {
        BGMsource.loop = true;
        PlayBGM(index);
    }

    public void PlayBGMOneShot(int index)
    {
        BGMsource.loop = false;
        PlayBGM(index);
    }

    public void StopBGM()
    {
        BGMsource.Stop();
    }

    public void PlaySELoop(int index)
    {
        PlaySE(index, true);
    }

    public void PlaySE(int index, bool loop=false)
    {
        var waitingSource = SEsources.Where(source => !source.isPlaying).First();

        if (!waitingSource)
        {
            Debug.LogWarning("AudioSourceが枯渇しています");
            return;
        }

        if (loop == true)
        {
            waitingSource.loop = true;
        }
        else
        {
            waitingSource.loop = false;
        }

        waitingSource.clip = clips[index];
        waitingSource.volume = volumes[index];
        waitingSource.Play();
    }

    public void StopSE(int index)
    {
        var playingSource = SEsources.Where(source => source.clip == clips[index]).First();
        playingSource.Stop();
    }

    public void PlaySE(int index, float delayTime)
    {
        StartCoroutine(PlaySELate(index, delayTime));
    }

    private IEnumerator PlaySELate(int index, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        PlaySE(index);
    }
}
