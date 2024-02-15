using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryObject : MonoBehaviour
{
    public string Name;
    [TextArea(3, 6)]
    public string Attributes;
    [TextArea(15, 40)]
    public string Desc;

    public Sprite Cat;
    public Vector3 Pos;
    public Vector3 localScale;
    public bool[] Flip;
}
