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
        audioSource.PlayOneShot(click);
        //Ŭ�� ����
        SceneManager.LoadScene("StartScene");
        //����ȭ������ �̵�

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
