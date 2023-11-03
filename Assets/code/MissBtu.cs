using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBtu : MonoBehaviour
{
        public AudioClip click;
        public AudioSource audioSource;
    
        public void Miss()
        {
                audioSource.PlayOneShot(click);
                Invoke("Reload", 0.2f);
        }
        public void Reload()
        {

            gameManager.I.giveUpPanel.SetActive(false);
        }

}
