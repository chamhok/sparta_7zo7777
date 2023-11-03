using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveUp : MonoBehaviour
{
        public AudioClip click;
        public AudioSource audioSource;

        public void GiveUp()
        {
                audioSource.PlayOneShot(click);
                gameManager.I.giveUpPanel.SetActive(true);
        }
}
