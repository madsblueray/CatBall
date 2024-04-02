using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.UIElements;


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
    public GameObject ball;
    public LaunchPoint LP;

    public int ballCount;
    public int curballCount;
    public float myDelay = 0.5f;
    

    public void Awake()
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
        Debug.Log("Tried to do MouseUp()");
        launchVector = Path.dir - new Vector2(transform.position.x, transform.position.y);
        launchVector.Scale(new Vector2(10f, 10f));
        Path.Reset();
        //BallLaunched.Invoke(LevelLoader.currentLevel);
        WinConditionManager.winState = false;
        BallLaunchedStatic.Invoke(LevelLoader.currentLevel);
        GetComponent<AudioSource>().Play();
        LP.LaunchBalls(launchVector);
        gameObject.SetActive(false);
    }

    public void disableLaunch()
    {
        allowedToLaunch = false;
    }

    public bool AllowedToLaunch()
    {
        return allowedToLaunch;
    }

}
