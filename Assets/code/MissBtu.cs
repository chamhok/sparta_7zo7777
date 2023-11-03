using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBtu : MonoBehaviour
{
        public AudioClip click;
        public AudioSource audioSource;
    
        public void Miss()
        {
                Time.timeScale = 1.0f;
                audioSource.PlayOneShot(click);
                Invoke("Reload", 0.1f);
        }
        public void Reload()
        {

            gameManager.I.giveUpPanel.SetActive(false);
        }

}
