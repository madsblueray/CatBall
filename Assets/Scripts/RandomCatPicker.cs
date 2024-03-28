using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCatPicker : MonoBehaviour, Bootstrapped
{
    //probably after most of the gallery stuff
    //need to update functionality to make the list cats that have been discovered
    public int priority = 3;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    public Sprite[] cats;

    public void Initialize()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = cats[Random.Range(0, cats.Length)];
    }
}
