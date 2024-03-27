using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ChildTextManager : MonoBehaviour, Bootstrapped
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }

    public TMP_Text[] texts;
    public bool TrueForWinUI;

    //best to turn the wobblers on and off with text because they do some math
    //behind the scenes that looks ugly in the console if on when the text is off

    void Start()
    {
        LevelLoader.OnLevelChange += changeChildTargets;
        if (TrueForWinUI) 
        {
            WinConditionManager.winEvent += Deploy;
            WinConditionManager.winEvent += PlaySound;
        }
        else
        {
            WinConditionManager.outOfTriesEvent += Deploy;
            WinConditionManager.outOfTriesEvent += PlaySound;
        }
    }

    public void Initialize()
    {
        LevelLoader.OnLevelChange += changeChildTargets;
        if (TrueForWinUI) 
        {
            WinConditionManager.winEvent += Deploy;
            WinConditionManager.winEvent += PlaySound;
        }
        else
        {
            WinConditionManager.outOfTriesEvent += Deploy;
            WinConditionManager.outOfTriesEvent += PlaySound;
        }
    }

    void Deploy()
    {
        EnableText(0);
        for (int i = 1; i < texts.Length; i++)
        {
            DelayedEnable(i);
        }
        
    }

    public void EnableText(int childIndex)
    {
        texts[childIndex].enabled = true;
        if (texts[childIndex].GetComponent<TextWobbler>())
        {
            texts[childIndex].GetComponent<TextWobbler>().enabled = true;
        }
        
    }

    public void DelayedEnable(int childIndex)
    {
        StartCoroutine(DECR(childIndex));
    }

    IEnumerator DECR(int childIndex)
    {
        yield return new WaitForSeconds(2.66f);
        texts[childIndex].enabled=true;
        texts[childIndex].GetComponent<TextWobbler>().enabled = true; 
    }

    public void disableText(int childIndex)
    {
        texts[childIndex].enabled = false;
        if (texts[childIndex].GetComponent<TextWobbler>())
        {
            texts[childIndex].GetComponent<TextWobbler>().enabled = false;
        }
    }

    public void disableAllText()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            disableText(i);
        }
    }

    void changeChildTargets(int levelIndex)
    {
        //maybe do something later :3c nya~
    }

    void PlaySound()
    {
        AudioSource victorySound = gameObject.GetComponent<AudioSource>();
        victorySound.Play();
    }
}
