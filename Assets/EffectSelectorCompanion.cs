using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EffectSelectorCompanion : MonoBehaviour
{
    public MusicManager musicManager;
    TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        text.text = musicManager.GetCurrentEffectName();
    }

    public void OnPress(bool forward)
    {
        int increment = forward? 1:-1;
        int cei = musicManager.current_effect_index;
        int length = musicManager.effects.Length;

        cei += increment;
        if (cei < 0) cei = length-1;
        cei %= length;

        Debug.Log("effect index being passed to the mm: " + cei);

        musicManager.ChangeEffects(cei);
        UpdateText();
    }
}
