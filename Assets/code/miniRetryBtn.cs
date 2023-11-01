using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class miniRetryBtn : MonoBehaviour
{
        public AudioClip click;
        public AudioSource audioSource;
        public void GameStart()
        {
                audioSource.PlayOneShot(click);
                SceneManager.LoadScene("StartScene");
        }
      
}
