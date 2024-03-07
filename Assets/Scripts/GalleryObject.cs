using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryObject : MonoBehaviour
{
    public delegate void GalleryObjectClicked(GalleryImgInfo ImgInfo, GalleryCatText CatText);
    public static event GalleryObjectClicked galleryObjectClicked;

    public GalleryObjReader reader;


    public string Name;
    [TextArea(3, 6)]
    public string Attributes;
    [TextArea(15, 40)]
    public string Desc;

    public Sprite Cat;
    public Vector3 Pos;
    public Vector3 localScale;
    public bool[] Flip;

    GalleryCatText gct;
    GalleryImgInfo gii;

    public void OnClickInvokeEvent()
    {
        gct = new GalleryCatText(Name, Attributes, Desc);
        gii = new GalleryImgInfo(Cat, Pos, localScale, Flip);
        
        reader.LoadReader(gii, gct);
    }
}
