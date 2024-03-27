using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.WSA;

public class BallManager : MonoBehaviour, Bootstrapped
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log("BallManager priority: " + priority);
            return priority;
        }
    }
    
    [SerializeField]
    public int ballsDestroyed;
    public int ballsExpected;

    LevelProperties lp;
    BallLauncher ball;

    public delegate void LauncherReady(int levelIndex);
    public static event LauncherReady LauncherReadyEvent;

    void Awake()
    {
        ball = GetComponentInChildren<BallLauncher>(true);
        lp = GetComponentInParent<LevelProperties>();

        LauncherReadyEvent.Invoke(lp.levelIndex);

        ProjectileBall.ballDestroyedInLevel += Decrement;

        LevelLoader.OnLevelChange += ResetBall;
        LevelLoader.OnLevelChange += ResetBallCount;
        LevelLoader.OnLevelChange += LauncherActive;
        
        ballsExpected = gameObject.GetComponentInChildren<BallLauncher>().ballCount;
    }

    public void Initialize()
    {
        ball = GetComponentInChildren<BallLauncher>(true);
        lp = GetComponentInParent<LevelProperties>();

        LauncherReadyEvent.Invoke(lp.levelIndex);

        ProjectileBall.ballDestroyedInLevel += Decrement;

        LevelLoader.OnLevelChange += ResetBall;
        LevelLoader.OnLevelChange += ResetBallCount;
        LevelLoader.OnLevelChange += LauncherActive;
        
        ballsExpected = gameObject.GetComponentInChildren<BallLauncher>().ballCount;
    }

    void LauncherActive(int level_index)
    {
        if (level_index == lp.levelIndex) LauncherReadyEvent.Invoke(lp.levelIndex);
    }

    void Decrement()
    {
        ballsDestroyed++;
    }
    void Decrement(int currentLevel)
    {
        if (currentLevel == lp.levelIndex)
        {
            Decrement();
            checkLose();
        }
    }

    void checkLose()
    {
        if ((ballsExpected == ballsDestroyed) && !WinConditionManager.winCheck())
        {
            Lose();
        }
    }

    void Lose()
    {
        Debug.Log("BallManager triggered loss");
        if (TriesCounter.OutOfTries())
        {
            WinConditionManager.OutOfTries();
        }
        else 
        {
            WinConditionManager.Lose();
            ResetBall();
        }
        ballsDestroyed = 0;
    }

    void ResetBall()
    {
        ball.gameObject.SetActive(true);
        ball.curballCount = ball.ballCount;
    }

    void ResetBall(int level_index)
    {
        if (LevelLoader.currentLevel == lp.levelIndex) ResetBall();
    }

    void ResetBallCount(int level_index)  
    {
        ballsDestroyed = 0;
    }
}
