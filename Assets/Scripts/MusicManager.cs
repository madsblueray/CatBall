using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class MusicManager : MonoBehaviour, IDataPersistence
{
    public bool mute;
    public int current_trackID;
    public int current_effect_index;

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
    public MusicEffect[] effects;
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
        Audio.volume = 0.6f;
        Audio.Play();
    }

    public void ChangeTracks(int trackID)
    {
        Audio.Stop();
        Audio.loop = true;
        current_trackID = trackID;
        Audio.clip = tracks[current_trackID-1].audio;
        Audio.volume = 0.6f;
        current_trackID = trackID;
        Audio.Play();
    }

    public void ChangeEffects(int effect_index)
    {
        MusicEffect effect = effects[effect_index];
        effect.ApplyEffect(Audio);
        current_effect_index = effect_index;
    }

    public string GetTrackName(int i)
    {
        return tracks[i].title;
    }

    public string GetCurrentEffectName()
    {
        return GetEffectName(current_effect_index);
    }

    public string GetEffectName(int i)
    {
        return effects[i].name;
    }

    public string GetCurrentTrackName()
    {
        return GetTrackName(current_trackID-1);
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

[System.Serializable]

public class MusicEffect
{
    public string name;
    public float pitch;
    public float pan;

    public MusicEffect(string name, float pitch = 1.0f, float pan = 0.0f)
    {
        this.name = name;
        this.pitch = pitch;
        this.pan = pan;
    }

    public void ApplyEffect(AudioSource audio)
    {
        audio.pitch = pitch;
        audio.panStereo = pan;
    }
}



