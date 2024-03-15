using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Store Config")]

    [SerializeField] string fileName;

    private GameData gameData;
    public static DataPersistenceManager instance {get; private set;}

    public List<IDataPersistence> dataPersistenceObjects;

    FileDataHandler dataHandler;

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("I QUIT!!!!!");
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
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
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

        dataHandler.Save(gameData);
    }

    List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        List<IDataPersistence> dataPersistenceObjects = new List<IDataPersistence>();
        MonoBehaviour[] monos = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour mono in monos)
        {
            var tempIData = mono as IDataPersistence;
            if (mono is IDataPersistence)
            {
                dataPersistenceObjects.Add(tempIData);
            }
        }
        return dataPersistenceObjects;
    }
}
