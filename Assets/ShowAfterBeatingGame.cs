using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAfterBeatingGame : MonoBehaviour
{
    void Awake()
    {
        LevelLoader.beatTheGameEvent += ShowCrown;
    }

    void Start()
    {
        ShowCrown();
    }

    void ShowCrown()
    {
        GetComponent<SpriteRenderer>().enabled = LevelLoader.beatTheGame;
    }
}
