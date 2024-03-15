using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TriesCounter : MonoBehaviour, IDataPersistence
{
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
    
    // Start is called before the first frame update
    void Awake()
    {
        BallLauncher.BallLaunchedStatic += LoseATry;
        WinConditionManager.lossEvent += IncreaseCounterWobble;
        WinConditionManager.outOfTriesEvent += Reset;
        WinConditionManager.winEvent += Reset;
        LevelLoader.OnLevelChange += EnableText;
        LevelLoader.OnLevelChange += UpdateText;
        text = gameObject.GetComponent<TMP_Text>();
        InitializeTries();
    }

    void InitializeTries(int levelIndex)
    {
        if (levelIndex == LevelLoader.currentLevel){
            InitializeTries();
        }
    }
    void InitializeTries()
    {
        if (Tries == 0)
        {
            Tries = 3;
        }
        if (curTries == 0)
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
        InitializeTries();
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
