using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEventHandler : MonoBehaviour
{
    public GameObject discoveredMessage;
    public CatsCollectedReader CCR;
    // Drag & drop the objects in the inspector
    public GameObject[] Targets;
    
    public TransformStorage[] SpawnPoints;

    public int destroyed;

    public ParticleSystem parsys;

    public delegate void LevelEvent();
    public static event LevelEvent allTargetsDisabled;

    
    void Awake()
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
        LevelLoader.OnLevelChange += RespawnTargets;
    }
    
    void handleTarget(int index)
    {
        SpawnParticlesAtTarget(index);
        if (CCR.DiscoverCat(Targets[index].GetComponent<Cattributes>().ID, true))
        {
            SpawnMessageAtTarget(index);
        }
        Targets[index].SetActive(false);
        destroyed++;
        checkForWin();
    }
    

    void SpawnParticlesAtTarget(int index)
    {
        ParticleSystem par = Instantiate(parsys, Targets[index].transform.position, new Quaternion(0,0,0,0));
        par.transform.localScale = Targets[index].transform.localScale;
    }

    void SpawnMessageAtTarget(int index)
    {
        Instantiate(discoveredMessage, Targets[index].transform.position, new Quaternion(0,0,0,0));
    }

    void RespawnTargets()
    {
        Debug.Log("Respawning targets in Level " + LevelLoader.currentLevel + "...");
        for( int i = 0 ; i < Targets.Length ; ++i )
        {
            Debug.Log("Respawning target " + i + "in level " + LevelLoader.currentLevel);
            SpawnPoints[i].setTransform(Targets[i].transform);
            Targets[i].SetActive(true);
            Targets[i].GetComponent<TargetCollisionSystem>().ResetHP();
        }
        destroyed = 0;
    } 

    void RespawnTargets(int levelIndex)
    {
        if (GetComponentInParent<LevelProperties>(true).levelIndex == LevelLoader.currentLevel)
        {
            RespawnTargets();
        } 
    } 

    void checkForWin()
    {
        if (destroyed == Targets.Length)
        {
            allTargetsDisabled.Invoke();
        }
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
