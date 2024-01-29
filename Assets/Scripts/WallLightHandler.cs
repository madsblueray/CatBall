using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WallLightHandler : MonoBehaviour
{
    Light2D[] lights;
    void Start()
    {
        lights = gameObject.GetComponentsInChildren<Light2D>();
        BallLauncher.BallLaunchedStatic += LightsOff;
        LevelLoader.OnLevelChange += LightsOn;
        
    }

    public void LightsOff(int levelIndex)
    {
        if (GetComponentInParent<LevelProperties>().levelIndex == levelIndex)
        {
            LightsOff();
        }
    }

    public void LightsOff()
    {
        foreach (Light2D light in lights)
        {
            Debug.Log(lights.Length);
            light.enabled = false;
        }
    }

    public void LightsOn(int levelIndex)
    {
        if (GetComponentInParent<LevelProperties>().levelIndex == levelIndex)
        {
            LightsOn();
        }
    }

    public void LightsOn()
    {
        foreach (Light2D light in lights)
        {
            Debug.Log(lights.Length);
            light.enabled = true;
        }
    }

    void CleanUp()
    {
        BallLauncher.BallLaunchedStatic -= LightsOff;
        LevelLoader.OnLevelChange -= LightsOn;
    }

    void OnDestroy()
    {
        CleanUp();
    }
}
