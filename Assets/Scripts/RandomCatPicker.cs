using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCatPicker : MonoBehaviour, Bootstrapped
{
    public int priority = 0;
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
        gameObject.GetComponent<SpriteRenderer>().sprite = cats[Random.Range(0, cats.Length)];
    }

    public void Initialize()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = cats[Random.Range(0, cats.Length)];
    }
}
