using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
         Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void openCard()
        {
                anim.SetBool("isOpen", true);

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
        }
}
