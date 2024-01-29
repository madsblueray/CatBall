using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TextWobbler : MonoBehaviour
{

    public TMP_Text textMesh;
    public Mesh mesh;
    public Vector3[] vertices;

    [Range(0f, 10f)]
    public float x;
    [Range(0f, 10f)]
    public float y;

    [Range(0f, 10f)]
    public float amplitude;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        
    }

    public virtual Vector2 Distort(float time)
    {
        return new Vector2(Mathf.Cos(time*x), Mathf.Sin(time*y))*amplitude;
    }
}
