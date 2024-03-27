using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    public GameObject topLevelParent;
    public void DestroyThis()
    {
        Destroy(topLevelParent? topLevelParent : gameObject);
    }
}
