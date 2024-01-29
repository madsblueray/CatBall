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
    [Range(0f, 10f)]
    public float LFO2_timescale;
    [Range(0f, 10f)]
    public float LFO2_amplitude;
    [Range(0f, 10f)]
    public float LFO2_offset;

    //0 for none, 1 for LFO1, 2 for LFO2
    [Range(0, 2)]
    public int OscColor;
    [Range(0, 2)]
    public int OscIntensity;
    [SerializeField] Gradient gradient;
    private List<Func<float>> funcs;

    void Start()
    {
        funcs = new List<Func<float>>();
        funcs.Add(LFO1);
        funcs.Add(LFO1);
        funcs.Add(LFO2);
    }

    void Update()
    {
        if (OscColor > 0)
        {
            gameObject.GetComponent<Light2D>().color = gradient.Evaluate(funcs[OscColor]());
        }

        if (OscIntensity > 0)
        {
            gameObject.GetComponent<Light2D>().intensity = funcs[OscIntensity]();
        }
    }

    float LFO1()
    {
        return Mathf.Sin(Time.time*LFO1_timescale)*LFO1_amplitude + LFO1_offset;
    }

    float LFO2()
    {
        return Mathf.Sin(Time.time*LFO2_timescale)*LFO2_amplitude + LFO2_offset;
    }
    
}
