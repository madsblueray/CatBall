using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public int cats_discovered;
    public int current_level;
    public int current_tries;
    public bool sfx_mute;
    public bool music_mute;
    public int trackID;

    public GameData(int cd, int cl, int ct, bool sfx, bool msx, int tid)
    {
        cats_discovered = cd;
        current_level = cl;
        current_tries = ct;
        sfx_mute = sfx;
        music_mute = msx;
        trackID = tid;
    }

    public GameData()
    {
        cats_discovered = 0;
        current_level = 1;
        current_tries = 3;
        sfx_mute = false;
        music_mute = false;
        trackID = 001;
    }


}
