using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    public int ballsDestroyed;
    public int ballsExpected;

    LevelProperties lp;
    BallLauncher ball;

    void Start()
    {
        lp = GetComponentInParent<LevelProperties>();
        ProjectileBall.ballDestroyedInLevel += Decrement;
        ballsExpected = gameObject.GetComponentInChildren<BallLauncher>().ballCount;
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

    void Win()
    {
        Debug.Log("BallManager triggered win");
        WinConditionManager.Win();
    }

    void CleanUp()
    {
        ballsDestroyed = 0;
        ballsExpected = 0;
        this.enabled = false;
    }

    void ResetBall()
    {
        ball = GetComponentInChildren<BallLauncher>(true);
        Debug.Log("ball: " + ball);
        ball.gameObject.SetActive(true);
        ball.curballCount = ball.ballCount;
        ball.GetComponent<SpriteRenderer>().enabled = true;
    }
}
