using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCatPicker : MonoBehaviour
{
    public Sprite[] cats;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = cats[Random.Range(0, cats.Length)];
    }
}
