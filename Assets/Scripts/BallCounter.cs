using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    [SerializeField] 
    public BallLauncher launcher;
    public TMP_Text text;
    // Start is called before the first frame update
    
    void Start()
    {
        //LevelLoader.OnLevelChange += ChangeBalls;
        BallManager.LauncherReadyEvent += ChangeBalls;
    }
    void Update()
    {
        text.text = "balls: " + launcher.curballCount.ToString();
        text.alpha = (float)launcher.curballCount/launcher.ballCount;
    }

    void ChangeBalls(int levelIndex)
    {
        launcher = LevelLoader.levels[levelIndex].GetComponentInChildren<BallLauncher>();
        text.alpha = 1;
        //launcher = temp;
    }
}
