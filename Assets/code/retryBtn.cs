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
        Invoke("Reload", 0.5f);
        
    }
    public void ReLoad()
    {
        SceneManager.LoadScene("MainScene");
    }


}
