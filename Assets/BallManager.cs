using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    
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
        ballsExpected = gameObject.GetComponentInChildren<BallLauncher>().ballCount;
        WinConditionManager.winEvent += CleanUp;
        LevelLoader.OnLevelChange += CleanUp;
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

    void CleanUp()
    {
        CleanUp(GetComponentInParent<LevelProperties>().levelIndex);
    }
    
    void CleanUp(int index)
    {
        if (index == LevelLoader.currentLevel)
        {
            ballsDestroyed = 0;
            ballsExpected = 0;
            ResetBall();
            gameObject.SetActive(false);
        }
        
    }

    void ResetBall()
    {
        ball.enabled = true;
        ball.gameObject.SetActive(true);
        ball.GetComponent<SpriteRenderer>().enabled = true;
        ball.curballCount = ball.ballCount;
        
    }

    
}
