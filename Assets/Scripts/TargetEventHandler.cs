using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEventHandler : MonoBehaviour
{
    // Drag & drop the objects in the inspector
    public GameObject[] Targets;
    
    public TransformStorage[] SpawnPoints;

    int destroyed;

    public ParticleSystem parsys;

    public delegate void LevelEvent();
    public static event LevelEvent allTargetsDisabled;

    
    void Start ()
    {
        SpawnPoints = new TransformStorage[Targets.Length];
        for( int i = 0 ; i < Targets.Length ; ++i )
        {
            Targets[i].GetComponent<TargetCollisionSystem>().targetPopped += handleTarget;
            Targets[i].GetComponent<TargetCollisionSystem>().index = i;
            SpawnPoints[i] = new TransformStorage();
            SpawnPoints[i].saveTransform(Targets[i].transform);
        }
        WinConditionManager.lossEvent += RespawnTargets;
    }
    
    void handleTarget(int index)
    {
        Debug.Log("TargetDeactivated");
        SpawnParticlesAtTarget(index);
        Targets[index].SetActive(false);
        destroyed++;
        checkForWin();
    }
    

    void SpawnParticlesAtTarget(int index)
    {
        Instantiate(parsys, Targets[index].transform.localPosition, new Quaternion(0,0,0,0));
    }

    void RespawnTargets()
    {
        for( int i = 0 ; i < Targets.Length ; ++i )
        {
            SpawnPoints[i].setTransform(Targets[i].transform);
            Targets[i].SetActive(true);
            Targets[i].GetComponent<TargetCollisionSystem>().ResetHP();
        }
        destroyed = 0;
    } 

    void checkForWin()
    {
        if (destroyed == Targets.Length)
        {
            Debug.Log("destroyed: " + destroyed + ", length: " +Targets.Length);
            allTargetsDisabled.Invoke();
        }
    }

    void RespawnBall()
    {
        
    }
}

public class TransformStorage
{
    Vector3 position;
    Quaternion rotation;
    Vector3 localScale;

    public void saveTransform(Transform a)
    {
        position = a.position;
        rotation = a.rotation;
        localScale = a.localScale;
    }

    public void setTransform(Transform a)
    {
        a.position = position;
        a.rotation = rotation;
        a.localScale = localScale;
    }
}
