using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TriesCounter : MonoBehaviour, IDataPersistence, Bootstrapped
{
    //after data has been loaded
    public int priority = 1;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public static int Tries {get; set;}
    public static int curTries {get; set;}
    TMP_Text text;

    public void LoadData(GameData data)
    {
        curTries = data.current_tries;
    }

    public void SaveData(ref GameData data)
    {
        data.current_tries = curTries;
    }

    public void Initialize()
    {
        BallLauncher.BallLaunchedStatic += LoseATry;
        WinConditionManager.lossEvent += IncreaseCounterWobble;
        WinConditionManager.outOfTriesEvent += Reset;
        WinConditionManager.winEvent += Reset;
        LevelLoader.OnLevelChange += EnableText;
        LevelLoader.OnLevelChange += UpdateText;
        text = gameObject.GetComponent<TMP_Text>();
        InitializeTries(true);
    }

    void InitializeTries(bool ignore)
    {
        if (Tries == 0)
        {
            Tries = 3;
        }
        if (curTries == 0 || ignore)
        {
            curTries = Tries;
            
        }
        UpdateText();
    }

    void LoseATry()
    {
        curTries--;
        UpdateText();
    }

    void LoseATry(int levelIndex)
    {
        LoseATry();
    }

    void IncreaseCounterWobble()
    {
        Debug.Log("IncreaseCounterWobble was called.");
        gameObject.GetComponent<TextWobblerCharacter>().amplitude+=(1f/Tries*2);
        gameObject.GetComponent<TextWobblerCharacter>().y+=.66667f;
    }

    void UpdateText()
    {
        text.text = "tries: " + curTries;
    }

    void UpdateText(int ballsack)
    {
        UpdateText();
    }
    
    public int GetTries()
    {
        return Tries;
    }

    public static bool OutOfTries()
    {
        return curTries == 0;
    }

    void Reset()
    {
        gameObject.GetComponent<TextWobblerCharacter>().amplitude=0;
        gameObject.GetComponent<TextWobblerCharacter>().y=0;
        InitializeTries(true);
        text.enabled = false;
    }

    void EnableText()
    {
        text.enabled = true;
    }

    void EnableText(int levelIndex)
    {
        if (levelIndex > 0)
        {
            EnableText();
        }  
    }
}
