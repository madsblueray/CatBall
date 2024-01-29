using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBall : MonoBehaviour
{

    public delegate void BallDestroyedInLevel(int level);
    public static event BallDestroyedInLevel ballDestroyedInLevel;

    void OnDestroy()
    {
        ballDestroyedInLevel.Invoke(LevelLoader.currentLevel);
    }


}
