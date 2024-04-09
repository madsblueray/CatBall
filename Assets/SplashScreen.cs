using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    public VideoPlayer player;

    void Start()
    {
        player.Play();
        StartCoroutine(WaitUntilVideoDone());
    }
    
    IEnumerator WaitUntilVideoDone()
    {
        yield return new WaitForSeconds((float)player.clip.length);
        SceneManager.LoadScene("CatBallGame");
        SceneManager.UnloadSceneAsync("splash_screen");
    }
}
