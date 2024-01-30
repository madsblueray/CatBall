using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class WallType : MonoBehaviour
{
    
    Light2D light_;
    LineRenderer line_;

    [SerializeField]
    public int type;
    public String position;
    public Color[] colors;

    public Gradient[] gradients;
    
    void Start()
    {
        light_ = GetComponentInChildren<Light2D>();
        light_.color = colors[type];

        line_ = GetComponentInChildren<LineRenderer>();
        line_.colorGradient = gradients[type];
    }

    public void OnCollisionEnter2D(Collision2D other) {
        switch (type)
        {
            case 1:
                DestroyBehaviour(other);
                break;
            case 2:
                TeleportBehaviour(other);
                break;
            default:
                break;
        }
    }

    void DestroyBehaviour(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        Destroy(other.gameObject);
    }

    void TeleportBehaviour(Collision2D other)
    {
        switch (position)
        {
            case "F":
                Nudge(other.transform, 0f, 15f);
                break;
            case "C":
                Nudge(other.transform, 0f, -15f);
                break;
            case "L":
                Nudge(other.transform, 8f, 0f);
                break;
            case "R":
                Nudge(other.transform, -8f, 16f);
                break;
            default:
                break;
        }
    }

    void Nudge(Transform other, float x, float y)
    {
        other.position = new Vector3(other.position.x + x, other.position.y + y, other.position.z);
    }
}
