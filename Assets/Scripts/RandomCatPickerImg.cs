using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCatPickerImg : MonoBehaviour, Bootstrapped
{
    //after random cat picker
    public int priority = 4;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public Sprite[] cats;

    void Start()
    {
        PickCat();
    }

    public void Initialize()
    {
        PickCat();
    }

    public void PickCat()
    {
        gameObject.GetComponent<Image>().sprite = cats[Random.Range(0, cats.Length)];
    }
}
