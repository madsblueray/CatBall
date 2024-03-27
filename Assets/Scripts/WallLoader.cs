using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLoader : MonoBehaviour
{
    public static WallType[] walls;
    // Start is called before the first frame update
    void Start()
    {
        walls = gameObject.GetComponentsInChildren<WallType>();
        LevelLoader.OnLevelChange += LoadWalls;
        LevelLoader.OnLevelChange += MoveWalls;
    }

    public void Initialize()
    {
        walls = gameObject.GetComponentsInChildren<WallType>();
        LevelLoader.OnLevelChange += LoadWalls;
        LevelLoader.OnLevelChange += MoveWalls;
    }
    static void LoadWalls(int levelIndex)
    {
        LoadWalls(LevelLoader.levels[levelIndex].GetComponent<LevelProperties>());
    }
    public static void LoadWalls()
    {
        LoadWalls(LevelLoader.levels[LevelLoader.currentLevel].GetComponent<LevelProperties>());
    }
    
    static void LoadWalls(LevelProperties lp)
    {
        if (lp.levelIndex > 0)
        {
            foreach (WallType wall in walls)
            {
                wall.type = lp.wallTypes[GetIndex(wall)];
                wall.RefreshColors();
            }
        }
    }

    static int GetIndex(WallType wall)
    {
        int ret = -1;

        switch(wall.position)
        {
            case "C":
                ret = 0;
                break;
            case "F":
                ret = 1;
                break;
            case "L":
                ret = 2;
                break;
            case "R":
                ret = 3;
                break;
        }

        return ret;
    }

    void MoveWalls(int index)
    {
        Debug.Log("HEllo?");
        Debug.Log(index);
        Debug.Log(30*index);
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(30*(index), pos.y, pos.z);
    }


}
