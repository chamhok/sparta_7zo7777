using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class retryBtn : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;

    public void ReGame()
    {
        audioSource.PlayOneShot(click);
        Time.timeScale = 1.0f;
        Invoke("goMainScene", 0.2f);
                
    }
        void goMainScene()
        {
                SceneManager.LoadScene("MainScene");
        }


}
