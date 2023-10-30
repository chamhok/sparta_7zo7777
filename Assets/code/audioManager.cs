using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgmusic;
    public Text timeTxt;
    bool isEnd = false;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1.0f;
        time += Time.deltaTime;

        if (time > 30.0f)
        {
            isEnd = true;

            if(isEnd == true)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }

        }
        
        
    }
}
