using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OscillateLightingValues : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f, 10f)]
    public float LFO1_timescale;
    [Range(0f, 10f)]
    public float LFO1_amplitude;
    [Range(0f, 10f)]
    public float LFO1_offset;

    void Update()
    {
        gameObject.GetComponent<Light2D>().intensity = LFO1();

    }

    float LFO1()
    {
        return Mathf.Sin(Time.time*LFO1_timescale)*LFO1_amplitude + LFO1_offset;
    }
}
