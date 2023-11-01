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

	private void Start()
	{
        presentOneShot(1.0f);
	}


	public void openCard()
    {
        audioSource.PlayOneShot(flip);
        //�������� ���� �Ҹ�

        anim.SetBool("isOpen", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        if (gameManager.I.firstCard == null)
        {
            gameManager.I.firstCard = gameObject;
			Invoke("timeOutCloseCard", 5.0f);
		}
        else
        {
			timeOutCheck();
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

    public void closeCardOneShot()
    {
		// presentOneshot용, 인보크를 쉽게 하기 위해 만든 함수
		anim.SetBool("isOpen", false);
	}

    public void timeOutCloseCard()
    {
        if(gameManager.I.firstCard == gameObject)
		    gameManager.I.firstCard = null;
		closeCardInvoke();
	}

    void timeOutCheck()
    {
        if (IsInvoking("timeOutCloseCard"))
            CancelInvoke("timeOutCloseCard");
    }

    void presentOneShot(float time)
    {
		// 게임 시작할 때 카드를 time만큼 보여주고 시작한다.
		anim.SetBool("isOpen", true);
		transform.Find("front").gameObject.SetActive(true);
		transform.Find("back").gameObject.SetActive(false);
		Invoke("closeCardOneShot", time);
	}
}
