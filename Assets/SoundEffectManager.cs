using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour, IDataPersistence
{
    public bool mute;

    public void LoadData(GameData data)
    {
        mute = data.sfx_mute;
    }

    public void SaveData(ref GameData data)
    {
        data.sfx_mute = mute;
    }
}
