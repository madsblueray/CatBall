using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    //Okay so basically this component will replace all the start functions in components
    //with their own "loader functions". after i do that, i can use this component to hold
    //the only Start() function, which will load everything in the perfect order that I want
    //Unfortunately this is gonna be a huge fucking bitch and i am not excited for it

    //Start vs awake: usually Awake() will be left alone. Any initializing operations
    //tucked into Start() will be replaced

    //find all instances of implementing the bootstrapped interface
    //sort them into priority order
    //exeute their initializer functions in that order, breaking ties by??? 
    //maybe just by component name
    List<Bootstrapped> objectsToLoad;

    void Awake()
    {
        InitializeBootstrappedComponents();
    }

    void InitializeBootstrappedComponents()
    {
        int rank = 1;
        objectsToLoad = FindAllBootstrappedComponents();
        objectsToLoad.Sort(IBCSortComparer);
        foreach(Bootstrapped obj in objectsToLoad)
        {
            Debug.Log(obj + " is initializing in rank: " + rank + " with priority: " + obj.Priority);
            obj.Initialize();
            
            rank++;
        }
        
    }

    int IBCSortComparer(Bootstrapped b1, Bootstrapped b2)
    {
        return Math.Sign(b1.Priority - b2.Priority);
    }

    List<Bootstrapped> FindAllBootstrappedComponents()
    {
        List<Bootstrapped> strappedObjects = new List<Bootstrapped>();
        MonoBehaviour[] monos = FindObjectsOfType<MonoBehaviour>(true);

        //the following part is not efficient at all but unity has not played nice
        //with FindOBjOfType so this is just a brute force workaround. cuz idk.
        foreach (MonoBehaviour mono in monos)
        {
            var tempBoot = mono as Bootstrapped;
            if (mono is Bootstrapped)
            {
                strappedObjects.Add(tempBoot);
            }
        }
        return strappedObjects;
    }
}
