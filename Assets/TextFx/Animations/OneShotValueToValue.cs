using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class OneShotValueToValue : MonoBehaviour
{
    public UnityEvent doneAnimating;
    TextWobbler TW;
    public AnimationCurve curve;
    [Range(1f, 10f)]
    public float time;
    [Range(-25f, 25f)]
    public float[] scale;
    public bool[] invert;
    public TWVS[] var;

    Action<float>[] func;
    float t = 0f;
    bool setupComplete = false;
    int varSize;

    float X;
    float Y;
    float Amp;


    void OnEnable()
    {
        varSize = var.Length;
        func = new Action<float>[var.Length];
        TW = gameObject.GetComponent<TextWobbler>();
        AnimationSetup();
    }

    void Update()
    {
        if(setupComplete)
        {
            for (int i = 0; i < varSize; i++)
            {
                if (invert[i])
                {
                    func[i]((1-curve.Evaluate(t))*scale[i]);
                }
                else
                {
                    func[i](curve.Evaluate(t)*scale[i]);
                }
            }
            if (t > time)
            {
                t = 0;
                doneAnimating.Invoke();
                enabled = false;
            }
            t += Time.deltaTime;
        } 
    }

    public void AnimationSetup()
    {
        curve.keys[1].time = time;
        for (int i = 0; i < varSize; i++)
        {
            switch (var[i])
            {
                case TWVS.x:
                    func[i] = TW.AddX;
                    break;
                case TWVS.y:
                    func[i] = TW.AddY;
                    break;
                case TWVS.amplitude:
                    func[i] = TW.AddAmplitude;
                    break;
                //case TWVS.alpha:
                    //func[i] = TW.SetAlpha;
                    //break;
                default:
                    break;
            }
        }
        setupComplete = true;
    }

    public enum TWVS
    {
        x = 0,
        y = 1,
        amplitude = 2,
        alpha = 3
    }
}
