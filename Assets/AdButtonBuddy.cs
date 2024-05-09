using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class AdButtonBuddy : MonoBehaviour
{
    TMP_Text text;
    CodelessIAPButton ad_button;
    Button button;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        ad_button = GetComponent<CodelessIAPButton>();
        button = GetComponent<Button>();
    }

    void Update()
    {
        if(AdManager.adsTurnedOff)
        {
            text.text = "ADS HAVE BEEN DISABLED!";
            button.enabled = false;
            ad_button.enabled = false;
        }
    }
}
