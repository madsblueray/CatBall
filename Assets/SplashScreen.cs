using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    public VideoPlayer player;
    

    void Start()
    {
        Application.targetFrameRate = 120;
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
