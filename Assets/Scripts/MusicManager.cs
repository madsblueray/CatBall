using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour, IDataPersistence
{
    public bool mute;
    public int current_trackID;

    public void LoadData(GameData data)
    {
        mute = data.music_mute;
        current_trackID = data.trackID;
    }

    public void SaveData(ref GameData data)
    {
        data.music_mute= mute;
        data.trackID = current_trackID;
    }

    public AudioSource Audio;

    public MusicTrack[] tracks;
    public AnimationCurve fadeIn;

    void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void Start()
    {
        PlayIntro();
    }

    public void DuckAway()
    {
        Audio.volume = 0.1f;
    }

    void PlayIntro()
    {
        Audio.Play();
        StartCoroutine(WaitForIntroMusicToEnd());
        
    }

    IEnumerator WaitForIntroMusicToEnd()
    {
        while (Audio.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1);
        //set the bgm track to be played and play it
        Audio.loop = true;
        Audio.clip = tracks[current_trackID-1].audio;
        Audio.volume = 0.75f;
        Audio.Play();
    }
}

[System.Serializable]
public class MusicTrack
{
    public string title;
    public AudioClip audio;

    public int ID;

    public MusicTrack(string tit, AudioClip aud, int id)
    {
        title = tit;
        audio = aud;
        ID = id;
    }
}



