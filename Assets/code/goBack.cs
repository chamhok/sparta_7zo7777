using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;

    public void goStartScene()
    {
                Time.timeScale = 1.0f;

                audioSource.PlayOneShot(click);//클릭 사운드

                
                Invoke("gotoStartScene", 0.1f);
        }
        //시작화면으로 이동
        void gotoStartScene()
        {
                SceneManager.LoadScene("StartScene");
        }

}
