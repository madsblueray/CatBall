using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;



public class LevelLoader : MonoBehaviour
{
    //Basically this thing is gonna drag and drop components
    //So that the moving UI is working and certain events are reset
    
    public delegate void ConfigureToLevel(int level);
    public static event ConfigureToLevel OnLevelChange;
    public static List<GameObject> levels;
    public static int currentLevel;
    [SerializeField] public int curLevDebug;
    public int startingLevel;
    public GameObject WinUI;
    public GameObject WinManager;

    /*void Update()
    {
        curLevDebug = currentLevel; i'm sorry  ;,,,,()
    }
    */
    void Start()
    {
        currentLevel = startingLevel;
        GenerateLevelsList();
        LoadLevel(currentLevel);
    }
    public void LoadLevel(int levelIndex)
    {
        //broadcast that it's time to set up a level back to square 1
        //hook up UI to that level's components
        OnLevelChange.Invoke(levelIndex);
        currentLevel = levelIndex;
        GameObject level = levels[levelIndex];
        if (levelIndex > 0) {
            level.GetComponentInChildren<BallManager>(true).gameObject.SetActive(true);
        }
        //GameObject platform = level.GetComponentInChildren<FollowCursor1D>(true).gameObject;
        //platform.SetActive(true);
    }

    public void NextLevel()
    {
        LoadLevel(currentLevel+1);
    }

    public void PrevLevel()
    {
        LoadLevel(currentLevel-1);
    }

    void GenerateLevelsList()
    {
        List<GameObject> temp = new List<GameObject>(GameObject.FindGameObjectsWithTag("Level"));  
        temp.Sort(GLLSortComparer);
        levels = temp;
    }

    private int GLLSortComparer(GameObject GO1, GameObject GO2)
    {
        int i1 = GO1.GetComponent<LevelProperties>().levelIndex;
        int i2 = GO2.GetComponent<LevelProperties>().levelIndex;

        if (i1>i2) return 1;
        if (i1<i2) return -1;
        return 0;
    }
}
