using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatsCollectedReader : MonoBehaviour, IDataPersistence, Bootstrapped
{
    
    //pretty early on
    //before data persistence
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public GameObject galleryContent;
    Dictionary<int, GameObject> gallery;
    int cats_discovered;
    int hidden_cats_teased = 5;
    HashSet<int> gallery_collected;

    public void Initialize()
    {
        LevelLoader.OnLevelChange += AdjustColorHiddenGalleryObjects;

        gallery = new Dictionary<int, GameObject>();
        gallery_collected = new HashSet<int>();
        foreach (Transform t in galleryContent.transform)
        {
            gallery.Add(t.GetComponent<GalleryObject>().ID, t.gameObject);
        }

        AdjustColorHiddenGalleryObjects();
    }

    public void SaveData(ref GameData data)
    {
        data.cats_discovered = cats_discovered;
    }

    public void LoadData(GameData data)
    {
        cats_discovered = data.cats_discovered;
        for (int i = 0; i < cats_discovered-1; i++)
        {
            Debug.Log("i: " + i + ", cats discovered: " + cats_discovered);
            DiscoverCat(i+1, false);
        }
    }

    public bool DiscoverCat(int cat_id, bool increment = true)
    {
        try
        {
            Debug.Log("Cattributes: " + cat_id);
            if (gallery_collected.Contains(cat_id)) throw new ArgumentException();
            gallery_collected.Add(cat_id);
            Debug.Log(gallery_collected.Count);
            Reveal(gallery[cat_id], cat_id);
            if (increment) cats_discovered++;
            return true;
        }

        catch (ArgumentException e)
        {
            Debug.Log("Tried to add a cat that has already been discovered. It's ok tho, we aint stressin' bout it fr fr." + e);
            return false;
        }
    }

    public void Reveal(GameObject gallery_obj, int ID)
    {
        try {
            gallery[ID].GetComponentInChildren<Image>(true).color = Color.white;
            
            gallery_obj.GetComponentInChildren<Button>(true).enabled = true;
        }

        catch (Exception e)
        {
            Debug.LogError("Most likely called CCR.Reveal on the wrong layer of an obj. " + e);
        }
    }

    //this func is supposed to show the cats to be discovered next as increasingly fading
    //silhouette 
    public void AdjustColorHiddenGalleryObjects()
    {
        IEnumerable<KeyValuePair<int, GameObject>> query = gallery.TakeWhile(obj => obj.Key > cats_discovered);

        foreach(KeyValuePair<int, GameObject> gallery_obj in query)
        {
            Image img = gallery_obj.Value.GetComponentInChildren<Image>(true);
            int diff = gallery_obj.Key - cats_discovered;
            if (diff > hidden_cats_teased) diff = 0;
            else diff--;
            Color c = new Color(0,0,0, (hidden_cats_teased-diff)*1f/hidden_cats_teased);
            img.color = c;
            Debug.Log("Cat " + gallery_obj.Key + " given color " + c);
        }
    }

    public void AdjustColorHiddenGalleryObjects(int boobies) //lol
    {
        AdjustColorHiddenGalleryObjects();
    }
}
