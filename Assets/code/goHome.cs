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
        audioSource.PlayOneShot(click);
        Destroy(GameObject.Find("difficultysend"));
                Invoke("gotoStartScene", 0.2f);
                Time.timeScale = 1.0f;
     }
        void gotoStartScene()
        {
                SceneManager.LoadScene("StartScene");
        }
}
