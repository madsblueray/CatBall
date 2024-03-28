using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class LevelProperties : MonoBehaviour, Bootstrapped
{
    //before level loader
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public int levelIndex;

    [Header("Wall order: Ceiling, Floor, Left, Right")]
    public int[] wallTypes;

    public void Initialize()
    {
        String num = gameObject.name[5..];
        Debug.Log(gameObject.name);
        Debug.Log(num);
        levelIndex = int.Parse(num);
        Debug.Log(levelIndex);
    }
}
