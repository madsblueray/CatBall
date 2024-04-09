using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToPhone : MonoBehaviour, Bootstrapped
{
    //this can probably go first
    //no troubling dependencies but this changes visual, otherwise would not be bootstrapped
    public int priority = 5;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
    // Start is called before the first frame update

   public void Initialize()
    {
        float aspect = (float)Screen.width / Screen.height;
        float targetAspect = 9f/16f;
        Debug.Log("Screen.width: " + Screen.width);
        Debug.Log("Screen.height: " + Screen.height);
        Debug.Log("Aspect: " + aspect);

        if (aspect > targetAspect)
        {
            Camera.main.orthographicSize = 8;
        }
        else{
            Camera.main.orthographicSize = 8 * (targetAspect/aspect);
        }
    }
}
