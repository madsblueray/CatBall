using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToPhone : MonoBehaviour, Bootstrapped
{
    //this can probably go first
    //no troubling dependencies but this changes visual, otherwise would not be bootstrapped
    public int priority = -1;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        float aspect = (float)Screen.width / Screen.height;
        Debug.Log("Screen.width: " + Screen.width);
        Debug.Log("Screen.height: " + Screen.height);
        Debug.Log("Aspect: " + aspect);
        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Max(16f, 9f / aspect)/2;
    }

   public void Initialize()
    {
        float aspect = (float)Screen.width / Screen.height;
        Debug.Log("Screen.width: " + Screen.width);
        Debug.Log("Screen.height: " + Screen.height);
        Debug.Log("Aspect: " + aspect);
        gameObject.GetComponent<Camera>().orthographicSize = Mathf.Max(16f, 9f / aspect)/2;
    }
}
