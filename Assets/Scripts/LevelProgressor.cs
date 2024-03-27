using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressor : MonoBehaviour, Bootstrapped
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    void Start()
    {
        LevelLoader.OnLevelChange += LoadLevel;
    }

    public void Initialize()
    {
        LevelLoader.OnLevelChange += LoadLevel;
    }
    public void NextLevel()
    {
        LoadLevel(LevelLoader.currentLevel+1);
    }

    public void LoadLevel(int index)
    {
        gameObject.transform.position = new Vector3(30*(index), 0, -10);
    }

}
