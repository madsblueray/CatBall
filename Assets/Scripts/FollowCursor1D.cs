using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class FollowCursor1D : MonoBehaviour, Bootstrapped
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }

    void Awake()
    {
        Activate();
    }

    public void Initialize()
    {
        Activate();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector2(x, -5);
    }

    void On()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void Off()
    {
        gameObject.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Activate()
    {
        On();
    }
}
