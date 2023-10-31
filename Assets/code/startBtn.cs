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
        SceneManager.LoadScene("MainScene");
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
