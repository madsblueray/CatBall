using System.Numerics;
using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector4 = UnityEngine.Vector4;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public class LaunchPath : MonoBehaviour
{

    [SerializeField] public LineRenderer path;
    public float length {get; set;}
    public float strength {get; set;}
    Color color = new Vector4(1,1,1,1);
    public Vector2 dir;

    void Awake()
    {
        path = GetComponent<LineRenderer>();
        path.positionCount = 2;
        path.SetPosition(0, transform.position);
        path.SetPosition(1, transform.position);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		path.sortingLayerID = spriteRenderer.sortingLayerID;
    }
    
    public void Reset()
    {
        length = 0.0f;
        strength = 0.0f;
        color = new Vector4(1,1,1,1);
        path.enabled = false;
        path.SetPosition(1, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        strength = length/5;
        color = new Vector4(1, 1-strength, 1-strength, 1-strength);
        path.endColor = color;
    }

    public void DrawLine(Vector3 point)
    {
        dir = transform.position - point;
        path.SetPosition(1, dir);
    }

}
