using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;

public class AdButtonBuddy : MonoBehaviour
{
    TMP_Text text;
    CodelessIAPButton button;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        button = GetComponent<CodelessIAPButton>();
    }

    void Update()
    {
        if(AdManager.adsTurnedOff)
        {
            text.text = "ADS HAVE BEEN DISABLED!";
            button.enabled = false;
        }
    }
}
