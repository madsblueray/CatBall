using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ImageWobbler : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Vector2[] vertices;

    [Range(0f, 10f)]
    public float x;
    [Range(0f, 10f)]
    public float y;

    [Range(0f, 10f)]
    public float amplitude;

    float x_temp;
    float y_temp;
    float amp_temp;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual Vector2 Distort(float time)
    {
        return new Vector2(Mathf.Cos(time*(x + x_temp)), Mathf.Sin(time*(y + y_temp)))*(amplitude + amp_temp);
    }

    public void AddX(float X){x_temp = X;}
    public void AddY(float Y){y_temp = Y;}
    public void AddAmplitude(float amp){amp_temp = amp;}

    //resets the mesh vertices, don't use :()

    
}
