using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//basically i change the width vs height scaling based on the screen's aspect ratio
public class CanvasScalerBuddy : MonoBehaviour
{
    public float debugMatch;

    void Start()
    {
        scaleThis();
    }
    void scaleThis()
    {
        CanvasScaler cs = GetComponent<CanvasScaler>();
        if ((float)Screen.width /(float)Screen.height < 9f/16f)
        {
            cs.matchWidthOrHeight = 0;
            debugMatch = 0;
        }
        else{
            cs.matchWidthOrHeight = 1;
            debugMatch = 1;
        }
    }


}
