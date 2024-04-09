using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WallLightHandler : MonoBehaviour
{
    Light2D[] lights;

    //in mobile version the lights are switched off for now
    void Awake()
    {
        lights = gameObject.GetComponentsInChildren<Light2D>(true);
        BallLauncher.BallLaunchedStatic += LightsOff;
        LevelLoader.OnLevelChange += LightsOn;
    }

    public void LightsOff(int levelIndex)
    {
        LightsOff();
    }

    public void LightsOff()
    {
        foreach (Light2D light in lights)
        {
            light.enabled = false;
        }
    }

    public void LightsOn(int levelIndex)
    {
        LightsOn();
    }

    public void LightsOn()
    {
        foreach (Light2D light in lights)
        {
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
