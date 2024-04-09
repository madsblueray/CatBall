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
        RefreshColors();
    }

    public void RefreshColors()
    {
        if (light_ != null)
        {
            light_ = GetComponentInChildren<Light2D>();
            light_.color = colors[type];
        }
        

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
        other.gameObject.GetComponent<ProjectileBall>().ClearTrail();
        if (other != null)
        {
            switch (position)
            {
                case "F":
                    NudgeY(other,2);
                    break;
                case "C":
                    NudgeY(other,-2);
                    break;
                case "L":
                    NudgeX(other, 2);
                    break;
                case "R":
                    NudgeX(other, -2);
                    break;
                default:
                    break;
            }
        }
        other.gameObject.GetComponent<ProjectileBall>().ClearTrail();
    }

    void NudgeX(Collision2D other, float x)
    {
        Transform T = other.transform;
        T.position = new Vector3(T.position.x + 4.15f*x, T.position.y, T.position.z);
        Vector3 V = other.gameObject.GetComponent<Rigidbody2D>().velocity;
        V = new Vector3(-V.x, V.y, V.z);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = V;
    }
    void NudgeY(Collision2D other, float y)
    {
        Transform T = other.transform;
        T.position = new Vector3(T.position.x, T.position.y + 7.65f*y, T.position.z);
        Vector3 V = other.gameObject.GetComponent<Rigidbody2D>().velocity;
        V = new Vector3(V.x, -V.y, V.z);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = V;
    }
}
