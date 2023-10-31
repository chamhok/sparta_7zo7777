using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;

class MyImage
{
    string name;
    string resourceName;

    public void SetName(string name)
    {
        this.name = name;
    }
    public void SetResourceName(string resourceName)
    {
        this.resourceName = resourceName;
    }
    public string GetName()
    {
        return this.name;
    }
    public string GetResourceName()
    {
        return this.resourceName;
    }
}

public class gameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip match;
    public AudioClip bgmusic;
    public AudioClip defeat;
    public AudioClip success;
    public AudioClip wrong;

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


    // 현재는 수동으로 배열의 갯수와 setImages 함수를 바꿔야 한다.
    // 차후에 스크립트(card.cs)에 변수를 할당하는 방식으로 고칠 수 있다.
    MyImage[] images = new MyImage[8];

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

        setImages();
        shuffleImages(images);

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
                    newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(images[i].GetResourceName());
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
            audioSource.clip = bgmusic;
            audioSource.Pause();
            audioSource.clip = defeat;
            audioSource.Play();
            //30초 지나면 실패 음악으로 변경
        }
        else if (time > 2.0f && !isHurry)
        {

            isHurry = true;
            timeTxtAnim.SetTrigger("isHurryUp");

        }
    }
    

    // 카드의 뒤집는 횟수를 센다.
    private void tryCounting()
    {
        tryCount++;
        tryTxt.text = tryCount + "번";
     }
    public void isMatched()
    {
        tryCounting();
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
                
                audioSource.clip = bgmusic;
                audioSource.Pause();
                audioSource.clip = success;
                audioSource.Play();
                //카드 매칭이 끝나면 배경음악중지, 성공음악 재생
            }
        }
        else
        {
            audioSource.PlayOneShot(wrong);
            setMatchTxt("꽝!!!");
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }
        if(IsInvoking("clearMatchTxt")) CancelInvoke("clearMatchTxt");
        Invoke("clearMatchTxt", 0.5f);

        firstCard = null;
        secondCard = null;
    }

    string setTxt(string name)
    {
        for(int i=0;i< images.Length; i++)
        {
            if(name == images[i].GetResourceName())
            {
                return images[i].GetName();
            }
        }
        return "오류";
    }

    void setMatchTxt(string txt)
    {
        matchTxt.text = txt;
    }

    void clearMatchTxt()
    {
        matchTxt.text ="";
    }

    // class의 배열을 랜덤하게 섞는 함수(인터넷에서 봄)
    MyImage[] shuffleImages(MyImage[] list)
    {
        int random1,  random2;
        MyImage temp;

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
    void setImages()
    {
        // 이미지의 이름과 파일명 할당
        // resource의 파일명은 setResourceName에, 사진 주인공은 setName
        images[0] = new MyImage();
        images[0].SetName("르탄이1");
        images[0].SetResourceName("rtan0");
        images[1] = new MyImage();
        images[1].SetName("르탄이2");
        images[1].SetResourceName("rtan1");
        images[2] = new MyImage();
        images[2].SetName("르탄이3");
        images[2].SetResourceName("rtan2");
        images[3] = new MyImage();
        images[3].SetName("르탄이4");
        images[3].SetResourceName("rtan3");
        images[4] = new MyImage();
        images[4].SetName("르탄이5");
        images[4].SetResourceName("rtan4");
        images[5] = new MyImage();
        images[5].SetName("르탄이6");
        images[5].SetResourceName("rtan5");
        images[6] = new MyImage();
        images[6].SetName("르탄이7");
        images[6].SetResourceName("rtan6");
        images[7] = new MyImage();
        images[7].SetName("르탄이8");
        images[7].SetResourceName("rtan7");
    }
}