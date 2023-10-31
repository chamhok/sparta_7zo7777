using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;

public class gameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip match;
    public AudioClip bgmusic;

    public Text timeTxt;
    public Text tryTxt;
    public Text matchTxt;
    float time = 0.0f;

    public GameObject endPanel;
    int tryCount = 0;
    public GameObject card;

    public static gameManager I;

    public GameObject firstCard;
    public GameObject secondCard;

    string[] images = { "rtan0", "rtan1", "rtan2", "rtan3", "rtan4", "rtan5", "rtan6", "rtan7" };
    int cardStocks = 0;
    int cardsLeft = 0;

    bool isEnd = false;
    bool isHurry = false;
    Animator timeTxtAnim;


    void Awake()
    {
        I = this;
        timeTxtAnim = timeTxt.gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        clearMatchTxt();
        isEnd = false;
        isHurry = false;
        cardStocks = 4*4;
        cardsLeft = cardStocks;
        bool[] check = new bool[cardStocks];

        Time.timeScale = 1.0f;

        audioSource.clip = bgmusic;
        audioSource.Play();//bgm 재생

        // Images Array 랜덤하게 섞기. 0번부터 요구하는 카드 갯수의 절반만 사용함.
        ShuffleArray(images);

        for (int i=0; i < cardStocks; i++)
        {
                check[i] = false;
        }

        for (int i = 0; i < cardStocks/2; i++)
        {
            int doubleCheck = 0;
            while(true)
            {
                int rand = Random.Range(0, cardStocks);
                if(check[rand] == false)
                {
                    check[rand] = true;
                    GameObject newCard = Instantiate(card);
                    newCard.transform.parent = GameObject.Find("cards").transform;
                    float x = (rand / 4) * 1.4f - 2.1f;
                    float y = (rand % 4) * 1.4f - 3.0f;
                    newCard.transform.position = new Vector3(x, y, 0);
                    newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(images[i]);
                    doubleCheck++;
                }
                if(doubleCheck >= 2)
                {
                    doubleCheck =0;
                    break;
                }
            }
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd) return;



        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time > 30.0f)
        {
            isEnd = true;

            endPanel.SetActive(true);
            Time.timeScale = 0.0f;

            audioSource.Pause();
            //30초 지나면 음악 중지
        }
        else if (time > 2.0f && !isHurry)
        {

            isHurry = true;
            timeTxtAnim.SetTrigger("isHurryUp");

        }
    }

    public void isMatched()
    {
        tryCount++;
        tryTxt.text = tryCount + "번";
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);
            cardsLeft -= 2;
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
            setMatchTxt(setTxt(firstCardImage));
            if (cardsLeft == 0)
            {
                endPanel.SetActive(true);
                Time.timeScale = 0.0f;
                
                audioSource.Pause();
                //카드 매칭이 끝나면 음악중지
            }
        }
        else
        {
            setMatchTxt("꽝!!!");
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }
        if(IsInvoking("clearMatchTxt")) CancelInvoke("clearMatchTxt");
        Invoke("clearMatchTxt", 0.5f);

        firstCard = null;
        secondCard = null;

        string setTxt(string name)
        {
            // init error risk
            int val = 10;
            for(int i=0; i < images.Length ; i++)
            {
                if(name == images[i]) val = i;
            }
            if(val < 3)
            {
                return ("르탄이!");
            }
            else if(val < 6)
            {
                return ("르탄이!!");
            }
            else if(val < 9)
            {
                return "르탄이!!!";
            }
            return "오류";
        }


    }

    void setMatchTxt(string txt)
    {
        matchTxt.text = txt;
    }

    void clearMatchTxt()
    {
        matchTxt.text ="";
    }

    string[] ShuffleArray(string[] list)
    {
        int random1,  random2;
        string temp;

        for (int i = 0; i < list.Length; ++i)
        {
            random1 = Random.Range(0, list.Length);
            random2 = Random.Range(0, list.Length);

            temp = list[random1];
            list[random1] = list[random2];
            list[random2] = temp;
        }

        return list;
    }
}