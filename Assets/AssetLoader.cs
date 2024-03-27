using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour
{
    //Okay so basically this component will replace all the start functions in components
    //with their own "loader functions". after i do that, i can use this component to hold
    //the only Start() function, which will load everything in the perfect order that I want
    //Unfortunately this is gonna be a huge fucking bitch and i am not excited for it

    //Start vs awake: usually Awake() will be left alone. Any initializing operations
    //tucked into Start() will be replaced
}
