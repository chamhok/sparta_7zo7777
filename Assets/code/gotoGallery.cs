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
        //Ŭ�� ����
        SceneManager.LoadScene("Gallery");
        //�������� �̵�

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
