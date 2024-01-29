using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEventHandler : MonoBehaviour
{
    // Drag & drop the objects in the inspector
    public TargetDisabledHandler[] Targets;

    // You will be able to add a function once all the objects are Disabled
    public delegate void OnAllObjectsDisabled();
    public static event OnAllObjectsDisabled onAllObjectsDisabled;
    
    void Start ()
    {
        for( int i = 0 ; i < Targets.Length ; ++i )
            Targets[i].OnObjectDisabled += OnObjectDisabled;
    }
    
    
    private void OnObjectDisabled (GameObject DisabledObject)
    {
        CheckAllObjectsAreDisabled();
    }
    
    
    private void CheckAllObjectsAreDisabled ()
    {    
        for( int i = 0 ; i < Targets.Length ; ++i )
        {
            //Debug.Log((Targets[i].isActiveAndEnabled) + ": check from targets[i]");
            if(Targets[i].isActiveAndEnabled)
                return;
        }

        //Debug.Log("made it past nullcheck");

        if( onAllObjectsDisabled != null)
        {
            Debug.Log("All objects disabled");
            onAllObjectsDisabled.Invoke(); 
        }
                  
    } 
}
