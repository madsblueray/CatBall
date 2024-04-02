using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaunchPoint : MonoBehaviour
{
    public int priority = 0;
    public int Priority
    {
        get {
            Debug.Log(name + " priority: " + priority);
            return priority;
        }
    }
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

                //search for the target event handler
                //for every gravity source add this ball to the attractable bodies
                
                GravitationalBody[] gravBodies = LevelLoader.levels[LevelLoader.currentLevel].GetComponentsInChildren<GravitationalBody>();
                foreach(GravitationalBody gravBody in gravBodies)
                {
                    gravBody.AddToGravityList(Copy.GetComponent<Rigidbody2D>());
                }

                yield return new WaitForSeconds(myDelay);
            }
        }
    }
}

