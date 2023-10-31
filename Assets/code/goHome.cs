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
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
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
