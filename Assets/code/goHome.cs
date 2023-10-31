using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class goGallery : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;

    public void GoHome()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene("StartScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
