using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    public int ballsDestroyed;
    public int ballsExpected;
    bool allowWin = false;

    LevelProperties lp;

    void Start()
    {
        lp = GetComponentInParent<LevelProperties>();
        ProjectileBall.ballDestroyedInLevel += Decrement;
        TargetEventHandler.onAllObjectsDisabled += filterTargetHandlerWinEvent;
        BallLauncher.BallLaunchedStatic += updateWinState;
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
            updateWinState();
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
        }
    }

    void filterTargetHandlerWinEvent()
    {
        if (allowWin)
        {
            Win();
        }
    }

    void Win()
    {
        Debug.Log("BallManager triggered win");
        WinConditionManager.Win();
    }

    void updateWinState(int levelIndex)
    {
        if (levelIndex == lp.levelIndex)
        {
            updateWinState();
        }
    }

    void updateWinState()
    {
        allowWin = ballsDestroyed < ballsExpected;
        Debug.Log("allowWin = " + allowWin);
    }

    void CleanUp()
    {
        ballsDestroyed = 0;
        ballsExpected = 0;
        this.enabled = false;
    }
}
