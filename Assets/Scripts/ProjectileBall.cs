using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBall : MonoBehaviour
{

    public delegate void BallDestroyedInLevel(int level);
    public static event BallDestroyedInLevel ballDestroyedInLevel;
    TrailRenderer trail;
    float time;

    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        time = trail.time;
    }

    void OnDestroy()
    {
        if (!WinConditionManager.winState)
        {
            ballDestroyedInLevel.Invoke(LevelLoader.currentLevel);
        }
    }

    public void PauseTrail()
    {
        trail.emitting = false;
    }

    public void ResumeTrail()
    {
        trail.emitting = true; 
    }

    public void ClearTrail()
    {
        trail.Clear();
    }
}
