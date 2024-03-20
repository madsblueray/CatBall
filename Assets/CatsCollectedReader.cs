using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatsCollectedReader : MonoBehaviour, IDataPersistence
{
    Dictionary<int, GameObject> gallery;
    int cats_discovered;
    int hidden_cats_teased = 5;
    Dictionary<int, string> gallery_collected;

    

    void Start()
    {
        LevelLoader.OnLevelChange += AdjustColorHiddenGalleryObjects;

        gallery = new Dictionary<int, GameObject>();
        gallery_collected = new Dictionary<int, string>();
        foreach (Transform t in transform)
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
    }

    public void DiscoverCat(Cattributes cat)
    {
        try
        {
            Debug.Log("Cattributes: " + cat);
            Debug.Log("gallery_collected: " + gallery_collected);
            gallery_collected.Add(cat.ID, cat.Name);
            Reveal(gallery[cat.ID], cat.ID);
        }

        catch (ArgumentException e)
        {
            Debug.Log("Tried to add a cat that has already been discovered. It's ok tho, we aint stressin' bout it fr fr." + e);
        }
    }

    public void Reveal(GameObject gallery_obj, int ID)
    {
        try {
            gallery[ID].GetComponentInChildren<Image>().color = Color.white;
            gallery_obj.GetComponentInChildren<Button>().enabled = true;
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
            img.color = new Color(0,0,0, 1 - 1f/diff);
        }
    }

    public void AdjustColorHiddenGalleryObjects(int boobies) //lol
    {
        AdjustColorHiddenGalleryObjects();
    }
}
