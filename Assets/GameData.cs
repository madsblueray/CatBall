using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int cats_discovered;
    public int current_level;
    public int current_tries;
    public bool sfx_mute;
    public bool music_mute;
    public bool shuffle;
    public int trackID;
    public int effectIndex;
    public bool adsTurnedOff;

    public GameData(int cd, int cl, int ct, bool sfx, bool msx, bool shuf, int tid, int eid)
    {
        cats_discovered = cd;
        current_level = cl;
        current_tries = ct;
        sfx_mute = sfx;
        music_mute = msx;
        shuffle = shuf;
        trackID = tid;
        effectIndex = eid;
    }

    public GameData()
    {
        cats_discovered = 0;
        current_level = 0;
        current_tries = 3;
        sfx_mute = false;
        music_mute = false;
        trackID = 001;
        effectIndex = 0;
        adsTurnedOff = false;
    }

    public void OutOfBoundsFixer()
    {
        if (current_tries < 1)
        {
            current_tries = 3;
            current_level = Math.Max(0, current_level - 1);
        }
    }


}
