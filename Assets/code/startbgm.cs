using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startbgm : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startBgm;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = startBgm;
        audioSource.Play();//bgm 재생
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
