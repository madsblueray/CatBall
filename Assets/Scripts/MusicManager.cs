using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public bool mute;

    public void LoadData(GameData data)
    {
        mute = data.music_mute;
    }

    public void SaveData(ref GameData data)
    {
        data.music_mute= mute;
    }

    public AudioSource Audio;
    public AnimationCurve fadeIn;

    public void DuckAway()
    {
        Audio.volume = 0.1f;
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
