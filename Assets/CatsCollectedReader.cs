using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsCollectedReader : MonoBehaviour, IDataPersistence
{
    int cats_discovered;
    Dictionary<int, string> catCollection;

    public void SaveData(ref GameData data)
    {
        data.cats_discovered = cats_discovered;
    }

    public void LoadData(GameData data)
    {
        cats_discovered = data.cats_discovered;
    }

    public void DiscoverCat(Cattributes cat)
    {
        try
        {
            catCollection.Add(cat.ID, cat.Name);
        }

        catch (ArgumentNullException e)
        {
            Debug.Log("Tried to add a cat that has already been discovered. It's ok tho, we aint stressin' bout it fr fr.");
        }
    }
}
