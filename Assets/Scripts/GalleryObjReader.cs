using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GalleryObjReader : MonoBehaviour, Bootstrapped
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public TMP_Text Name;
    public TMP_Text Attributes;
    public TMP_Text Desc;

    public SpriteRenderer SR;

    void Start()
    {
        GalleryObject.galleryObjectClicked += LoadReader;
    }

    public void Initialize()
    {
        GalleryObject.galleryObjectClicked += LoadReader;
    }

    public void LoadReader(GalleryImgInfo ImgInfo, GalleryCatText CatText)
    {
        ImgInfo.LoadAttributesToSpriteRenderer(SR);
        CatText.LoadAttributesToTMP(Name, Attributes, Desc);
    }
}

public class GalleryImgInfo
{
    public Sprite Cat;
    Vector3 Pos;
    Vector3 Scale;
    bool[] Flip;

    public GalleryImgInfo(SpriteRenderer sr)
    {
        Cat = sr.sprite;
        Pos = sr.gameObject.transform.localPosition;
        Scale = sr.gameObject.transform.localScale;
        Flip = new bool[] {sr.flipX, sr.flipY};
    }

    //this info will be stored in some simple component on the gallery object proba
    public GalleryImgInfo(Sprite cat, Vector3 pos, Vector3 scale, bool[] flip)
    {
        Cat = cat;
        Pos = pos;
        Scale = scale;
        Flip = flip;
    }

    public void LoadAttributesToSpriteRenderer(SpriteRenderer sr)
    {
        sr.sprite = Cat;
        sr.transform.localPosition = Pos;
        sr.transform.localScale = Scale;
        sr.flipX = Flip[0];
        sr.flipY = Flip[1];
    }
}

public class GalleryCatText
{
    string Name;
    string Attributes;
    string Desc;

    public GalleryCatText(string name, string attributes, string desc)
    {
        Name = name;
        Attributes = attributes;
        Desc = desc;
    }

    public void LoadAttributesToTMP(TMP_Text name, TMP_Text attr, TMP_Text desc)
    {
        name.text = Name;
        attr.text = Attributes;
        desc.text = Desc;
    }
}
