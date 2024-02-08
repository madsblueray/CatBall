using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPoint : MonoBehaviour
{
    public BallLauncher BL;
    public GameObject ball;
    public float myDelay = 0.15f;

    void Start()
    {
        transform.position = BL.transform.position;
    }

    public void LaunchBalls(Vector2 launchVector) 
    {
        StartCoroutine(LaunchCopy(launchVector));
    }

    IEnumerator LaunchCopy(Vector2 launchVector)
    {
        for (int i = 0; i < BL.ballCount; i++)
        {
            if (BL.AllowedToLaunch())
            {
                BL.curballCount--;
                var Copy = Instantiate(ball, transform.position, transform.rotation);
                Copy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Copy.GetComponent<Rigidbody2D>().velocity = launchVector*.75f;
                //Copy.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.9f, 1f, 1f, 1f);
                yield return new WaitForSeconds(myDelay);
            }
        }
    }
}

