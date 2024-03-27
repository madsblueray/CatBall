using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.WSA;

public class WinConditionManager : MonoBehaviour, Bootstrapped
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public static bool winState = true;
    public delegate void EndOfGameEvent();
    public static event EndOfGameEvent lossEvent;
    public static event EndOfGameEvent winEvent;
    public static event EndOfGameEvent outOfTriesEvent;

    // Update is called once per frame
    void Start()
    {
        LevelLoader.OnLevelChange += EndOfLevelCleanup;
        TargetEventHandler.allTargetsDisabled += Win;
        //TargetEventHandler.onAllObjectsDisabled += Win;
    }

    public void Initialize()
    {
        LevelLoader.OnLevelChange += EndOfLevelCleanup;
        TargetEventHandler.allTargetsDisabled += Win;
        //TargetEventHandler.onAllObjectsDisabled += Win;
    }

    public static void Win()
    {
        winState = true;
        FreezeProjectiles();
        BallManager bm =LevelLoader.levels[LevelLoader.currentLevel].GetComponentInChildren<BallManager>();
        bm.enabled = false;
        Debug.Log("Win Triggered");
        winEvent.Invoke();
    }

    public static void Lose()
    {
        Debug.Log("tried to call lose, winstate was: " + winState);
        lossEvent.Invoke();
    }

    public static void OutOfTries()
    {
        Debug.Log("tried to call outoftries, winstate was: " + winState);
        outOfTriesEvent.Invoke();   
    }

    public static void FreezeProjectiles()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }

    public static void DestroyProjectiles()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < balls.Length; i++)
        {
            Destroy(balls[i]);
        }
    }

    public static void DestroyParticles()
    {
        GameObject[] parts = GameObject.FindGameObjectsWithTag("Particle");
        for (int i = 0; i < parts.Length; i++)
        {
            Destroy(parts[i]);
        }
    }

    public static void EndOfLevelCleanup(int whocares)
    {
        DestroyParticles();
        DestroyProjectiles();
        winState = true;
    }

    public static bool winCheck()
    {
        return WinConditionManager.winState;
    }

    //IEnumerator SlowlyKillBalls(GameObject[] balls)
    //{
    //    balls = GameObject.FindGameObjectsWithTag("Ball");
    //    while(balls != null)
    //    {
    //        yield return new WaitForSecondsRealtime(0.333f);
    //        balls[0].GetComponent<BallLauncher>().Explode();
    //        balls = GameObject.FindGameObjectsWithTag("Ball");
    //    }
    //}
}
