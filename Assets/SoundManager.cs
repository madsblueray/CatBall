using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour, IDataPersistence, Bootstrapped
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public delegate void SyncToggleUI();
    public static event SyncToggleUI LoadSoundDataSyncUI;
    public AudioMixer mixer;
    public static bool mute_sfx;
    public static bool mute_music;

    float mute_vol = -79.9f;

    void Start()
    {
        SfxToggleCompanion.SFXToggleUpdate += ToggleMute;
        ToggleMute(true, mute_sfx);
        ToggleMute(false, mute_music);
    }

    public void Initialize()
    {
        SfxToggleCompanion.SFXToggleUpdate += ToggleMute;
        ToggleMute(true, mute_sfx);
        ToggleMute(false, mute_music);

        LoadSoundDataSyncUI?.Invoke();
    }
    void Awake()
    {
        LoadSoundDataSyncUI?.Invoke();
    }

    public void LoadData(GameData data)
    {
        mute_sfx = data.sfx_mute;
        mute_music = data.music_mute;
    }

    public void SaveData(ref GameData data)
    {
        data.sfx_mute = mute_sfx;
        data.music_mute = mute_music;
    }

    public void ToggleMute(bool true_for_sfx, bool value)
    {
        if (true_for_sfx)
        {
            mixer.SetFloat("SFX_vol", value?mute_vol:0.255f);
            Debug.Log((value?1:0) * mute_vol);
        }
        else
        {
            mixer.SetFloat("MSX_vol", value?mute_vol:0.255f);
            Debug.Log((value?1:0) * mute_vol);
        }
    }
}
