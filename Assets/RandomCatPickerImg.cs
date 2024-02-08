using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCatPickerImg : MonoBehaviour
{
    public Sprite[] cats;

    void Start()
    {
        PickCat();
    }

    public void PickCat()
    {
        gameObject.GetComponent<Image>().sprite = cats[Random.Range(0, cats.Length)];
    }
}
