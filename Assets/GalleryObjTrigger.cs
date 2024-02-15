using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GalleryObjTrigger : MonoBehaviour
{
    public GalleryObjReader galleryObjReader;
    public void OnClick()
    {
        Debug.Log("got clicked");
        galleryObjReader.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
