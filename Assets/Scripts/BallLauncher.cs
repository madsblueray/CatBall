using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Experimental.AI;
using Unity.VisualScripting;
using System.Threading;
using UnityEditor;

public class BallLauncher : MonoBehaviour
{
    public delegate void BallLaunchEvent(int levelIndex);
    public event BallLaunchEvent BallLaunched;
    public static event BallLaunchEvent BallLaunchedStatic;
    private bool allowedToLaunch = true;
    public Vector3 launchOrigin = new Vector3();
    public Vector3 pullPoint = new Vector3();
    Transform origin;

    Vector2 launchVector;
    [SerializeField] public LaunchPath Path;
    public Rigidbody2D rb2d;
    public GameObject ball;

    public int ballCount;
    public int curballCount;
    public float myDelay = 0.5f;
    
    void Start()
    {
        curballCount = ballCount;
    }

    void OnMouseDown() {
        Path.path.enabled = true;
        launchOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        pullPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Path.length = Mathf.Min(Vector2.Distance(pullPoint, launchOrigin), 5);
        Path.DrawLine(pullPoint - launchOrigin);

        
    }

    void OnMouseUp() {
        launchVector = Path.dir - new Vector2(transform.position.x, transform.position.y);
        launchVector.Scale(new Vector2(10f, 10f));
        Path.Reset();
        //BallLaunched.Invoke(LevelLoader.currentLevel);
        BallLaunchedStatic.Invoke(LevelLoader.currentLevel);
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(LaunchCopy());
    }

    IEnumerator LaunchCopy()
    {
        for (int i = 0; i < ballCount; i++)
        {
            if (allowedToLaunch)
            {
                curballCount--;
                var Copy = Instantiate(ball, transform.position, transform.rotation);
                Copy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Copy.GetComponent<Rigidbody2D>().velocity = launchVector*.75f;
                //Copy.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.9f, 1f, 1f, 1f);
                yield return new WaitForSeconds(myDelay);
            }
        }
        gameObject.SetActive(false);
    }

    public void disableLaunch()
    {
        allowedToLaunch = false;
    }

}
