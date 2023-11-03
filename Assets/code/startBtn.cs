using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class startBtn : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;

    public void GameStart()
    {
        audioSource.PlayOneShot(click);
                Invoke("goMainScene", 0.2f);

        }
        void goMainScene()
        {
                SceneManager.LoadScene("MainScene");
        }

}
