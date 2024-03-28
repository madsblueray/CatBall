using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleToggleCompanion : MonoBehaviour
{

    [SerializeField]
    public Toggle toggle;
    public MusicManager musicManager;
    
    public delegate void ShuffleToggle(bool value);
    public static event ShuffleToggle ShuffleToggleUpdate;

    void Start()
    {
        SyncToggle();
    }

    public void Toggled()
    {
        musicManager.shuffle = toggle.isOn;
    }

    public void SyncToggle()
    {
        toggle.isOn = musicManager.shuffle;
        Debug.Log("toggle.isOn: " + toggle.isOn);
    }
}
