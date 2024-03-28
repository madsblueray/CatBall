 using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCounter : MonoBehaviour, Bootstrapped
{
    //before launcher ready event is used
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log("BallCounter priority: " + priority);
            return priority;
        }
    }

    [SerializeField] 
    public BallLauncher launcher;
    public TMP_Text text;
    // Start is called before the first frame update

    public void Initialize()
    {
        BallManager.LauncherReadyEvent += ChangeBalls;
    }


    void Update()
    {
        text.text = "balls: " + launcher.curballCount.ToString();
        text.alpha = (float)launcher.curballCount/launcher.ballCount;
    }

    void ChangeBalls(int levelIndex)
    {
        launcher = LevelLoader.levels[levelIndex].GetComponentInChildren<BallLauncher>(true);
        text.alpha = 1;
        //launcher = temp;
    }
}
