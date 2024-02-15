using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryObjReader : MonoBehaviour
{
    
}

public struct GalleryImgInfo
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
        sr.transform.position = Pos;
        sr.transform.localScale = Scale;
        sr.flipX = Flip[0];
        sr.flipY = Flip[1];
    }
}

public class GalleryCatText
{
    string name;
    string attributes;
    string desc;
}
