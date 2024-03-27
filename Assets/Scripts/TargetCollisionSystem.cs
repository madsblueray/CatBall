using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetCollisionSystem : MonoBehaviour
{
    [SerializeField] 
    public int index;
    public float shrinkAmt;
    public float rotateAmt;
    public float pushAmt;
    public int HP; 
    private int curHP;
    public TMP_Text text;
    public int anchorPoint = 4;
    private readonly Vector2[,] anchorPoints = new Vector2[3,3];

    bool popped = false;
    
    

    /// <summary>
    /// When the following bools are enabled, the initializer function will add
    /// each of the selected methdos to occur when a ball hits the target
    /// </summary>

    public bool shrinkOnHit;
    public bool rotateOnHit;
    public bool pushOnHit;
    public bool stopBallVelocityOnHit;
    public bool shrinkBallOnHit;
    public bool changeBallColorOnHit;
    public bool explodeBallOnHit;
    public bool splitBallOnHit;
    public bool changeBallShapeOnHit;


    public delegate void TargetPopped(int index);
    public event TargetPopped targetPopped;


    void Start()
    {
        curHP = HP;
        InitializeAnchorPoints();
        
    }
    void Update()
    {
        text.text = curHP.ToString();
    }

    public void playSound()
    {
        float inc = (HP-curHP) * 1.5f/HP;
        AudioSource impactSound = gameObject.GetComponent<AudioSource>();
        impactSound.pitch = 1 + inc;
        impactSound.Play();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        curHP-=1;
		playSound();

        if (curHP < 1 && !popped)
        {
            Debug.Log("this target was called to be popped: " + index);
            targetPopped.Invoke(index);
            popped = true;
        }

        if (shrinkOnHit) Shrink(other);
        if (rotateOnHit) Rotate(other);
        if (pushOnHit)   Push(other);
    }

    void InitializeAnchorPoints()
    {
        int[] X = {-1, 0, 1};
        int[] Y = {1, 0, -1};

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                anchorPoints[y,x] = new Vector2(X[x], Y[y]);
            }
        }
    }

    Vector2 getAnchorPointValues(int anchorPoint)
    {
        return anchorPoints[anchorPoint/3,anchorPoint%3];
    }

    public Vector3 NudgeWithAnchor(Vector3 pos, Vector2 nudgeAmts, int anchorPoint)
    {   
        float x = pos.x;
        float y = pos.y;
        Vector2 anchorVal = getAnchorPointValues(anchorPoint);
        x += nudgeAmts.x*anchorVal.x;
        y += nudgeAmts.y*anchorVal.y;
        return new Vector3(x, y, pos.z);
    } 

    public void Shrink(Collision2D other)
    {
        Vector2 size = gameObject.GetComponent<SpriteRenderer>().size;
        transform.localPosition = NudgeWithAnchor(transform.localPosition, size*Mathf.Sign(shrinkAmt)*Mathf.Pow(Mathf.Abs(shrinkAmt),1.5f)/2.33f, anchorPoint);
        transform.localScale*=(1-shrinkAmt);
    }

    public void Rotate(Collision2D other)
    {
        other.otherCollider.gameObject.transform.Rotate(0,0,rotateAmt);
    }

    public void Push(Collision2D other)
    {
        Vector2 dir = other.relativeVelocity;
        other.otherCollider.gameObject.transform.localPosition += new Vector3(dir.x, dir.y, 0)*pushAmt;
    }

    public void ResetHP()
    {
        curHP = HP;
        popped = false;
    }
}
