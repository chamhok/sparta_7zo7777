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
		SceneManager.LoadScene("Gallery");
		//갤러리로 이동

	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
