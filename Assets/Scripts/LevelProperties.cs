using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class LevelProperties : MonoBehaviour
{
    public int levelIndex;
    public GameObject prefabReference;
    void Start()
    {
        String num = gameObject.name[^1] + " ";
        levelIndex = int.Parse(num);
    }

    public GameObject SpawnCopy()
    {
        
        return Instantiate(prefabReference);
    }
}
