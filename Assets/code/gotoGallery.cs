using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoGallery : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;

    public void GoGallery()
    {
                Time.timeScale = 1.0f;
                audioSource.PlayOneShot(click);
               

                //클릭 사운드
                Invoke("goGallery", 0.1f);
                //갤러리로 이동

        }
        void goGallery()
        {
                SceneManager.LoadScene("Gallery");
        }
}
