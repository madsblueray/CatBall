using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audio;
    public AnimationCurve fadeIn;
    public bool enableMusic;
    public static bool enableSFX;

    public void DuckAway()
    {
        audio.volume = 0.1f;
    }
}

[System.Serializable]
public class MusicTrack
{
    public string title;
    public AudioClip audio;

    public MusicTrack(string tit, AudioClip aud)
    {
        title = tit;
        audio = aud;
    }
}
