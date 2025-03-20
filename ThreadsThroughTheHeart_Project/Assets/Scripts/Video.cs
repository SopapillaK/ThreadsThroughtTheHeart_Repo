using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//the scene that you want to load after the video has ended.
    }
}
