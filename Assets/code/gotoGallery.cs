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
        audioSource.PlayOneShot(click);
                //클릭 사운드
                Invoke("goGallery", 0.2f);
                //갤러리로 이동

        }
        void goGallery()
        {
                SceneManager.LoadScene("Gallery");
        }
}
