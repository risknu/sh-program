using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingScene : MonoBehaviour
{
    [Header("Cutscene Settings")]
    public VideoPlayer videoPlayer;
    public string nextSceneName = "AbilityChooseScene";


    public void Awake()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    public void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
