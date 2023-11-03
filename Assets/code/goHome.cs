using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GoHome : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;

    public void goHome()
    {
                Time.timeScale = 1.0f;
                audioSource.PlayOneShot(click);
        Destroy(GameObject.Find("difficultysend"));
                Invoke("gotoStartScene", 0.1f);
                
     }
        void gotoStartScene()
        {
                SceneManager.LoadScene("StartScene");
        }
}
