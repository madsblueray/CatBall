using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{

    private GameData gameData;
    public static DataPersistenceManager instance {get; private set;}

    public List<IDataPersistence> dataPersistenceObjects;

    private void Start()
    {
        LoadGame();
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("DPManager already exists");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if (instance == null)
        {
            Debug.LogError("No data found, loading new game");
            NewGame();
        }
        instance = this;

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(this.gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref this.gameData);
        }
    }

    List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
