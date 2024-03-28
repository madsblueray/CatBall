using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SfxToggleCompanion : MonoBehaviour, Bootstrapped
{
    //before LoadSoundDataSyncUI is called
    public int priority = 1;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }

    [SerializeField]
    public Toggle toggle;
    public bool is_sfx;
    
    public delegate void SFXToggle(bool true_for_sfx, bool value);
    public static event SFXToggle SFXToggleUpdate;

    public void Initialize()
    {
        SoundManager.LoadSoundDataSyncUI += SyncToggle;
    }

    public void Toggled()
    {
        SFXToggleUpdate.Invoke(is_sfx, toggle.isOn);
    }

    public void SyncToggle()
    {
        toggle.isOn = is_sfx ? SoundManager.mute_sfx : SoundManager.mute_music;
        Debug.Log("toggle.isOn: " + toggle.isOn);
    }
}
