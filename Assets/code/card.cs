using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public AudioClip flip;
    public AudioSource audioSource;

    bool opencheck = false;

    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void openCard()
    {
        audioSource.PlayOneShot(flip);
        //뒤집을때 나는 소리

        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        if (gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
        }
        else
        {
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatched();
        }
    }
    public void destroyCard()
        {
                Invoke("destroyCardInvoke", 0.5f);
        }

        void destroyCardInvoke()
        {
                Destroy(gameObject);
        }

        public void closeCard()
        {
                Invoke("closeCardInvoke", 0.5f);
        }

        void closeCardInvoke()
        {
               anim.SetBool("isOpen", false);
            if (!opencheck)
            {
                transform.Find("back").GetComponent<SpriteRenderer>().color = new Color(0.7058824f, 0.7058824f, 0.7058824f, 1f);
                opencheck = true;
            }
    }
}
