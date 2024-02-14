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

    public GalleryImgTransform(SpriteRenderer sr)
    {
        Cat = sr.sprite;
        Pos = sr.gameObject.transform.localPosition;
        Scale = sr.gameObject.transform.scale;
        Flip = new bool[sr.flipX, sr.flipY];
    }

    //this info will be stored in some simple component on the gallery object proba
    public GalleryImgTransform(Sprite cat, Vector3 pos, Vector3 scale, bool[] flip)
    {
        Cat = cat;
        Pos = pos;
        Scale = scale;
        Flip = flip;
    }

    public void LoadAttributesToSpriteRenderer(SpriteRenderer sr)
    {

    }

}

public class GalleryCatText
{
    String name;
    String attributes;
    String desc;
}
