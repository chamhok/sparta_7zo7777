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

    public Text fastestTxt;
    public Text currentScoreTxt;
    public Text highScoreTxt;
    public Text timeTxt;
    public Text tryTxt;
    public Text matchTxt;
    float time = 0.0f;

    public GameObject endPanel;
    int tryCount = 0;
    public GameObject card;
    public GameObject cards;

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
                    newCard.transform.name = images[i].GetName(); // 카드에게 각각 이름을 부여
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
                // 게임종료, endpanel 활성화 + 점수 계산
                endPanel.SetActive(true);
                Time.timeScale = 0.0f;
                setEndPanel();
                
                audioSource.clip = bgmusic;
                audioSource.Pause();
                audioSource.clip = success;
                audioSource.Play();
                //카드 매칭이 끝나면 배경음악중지, 성공음악 재생
            }
        }
        else
                {
                        cathide();
                        audioSource.PlayOneShot(wrong);
                        setMatchTxt("꽝!!!");
                        firstCard.GetComponent<card>().closeCard();
                        secondCard.GetComponent<card>().closeCard();
                }
                if (IsInvoking("clearMatchTxt")) CancelInvoke("clearMatchTxt");
        Invoke("clearMatchTxt", 0.5f);

        firstCard = null;
        secondCard = null;
    }
        //고양이의 위치를 바꾼다.
        private void cathide()
        {
                if (firstCard.transform.name == "군침냥") // 퍼스트 카드의 이름이 군침냥(추후수정)인지 확인 
                {
                        Vector3 tempPosition = firstCard.transform.position; 
                        firstCard.transform.position = cards.transform.GetChild(1).position;
                        cards.transform.GetChild(1).position = tempPosition;
                }
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
        images[0].SetName("황선범");
        images[0].SetResourceName("team0");
        images[1] = new MyImage();
        images[1].SetName("전은하");
        images[1].SetResourceName("team1");
        images[2] = new MyImage();
        images[2].SetName("박기혁");
        images[2].SetResourceName("team2");
        images[3] = new MyImage();
        images[3].SetName("정용태");
        images[3].SetResourceName("team3");
        images[4] = new MyImage();
        images[4].SetName("강건욱");
        images[4].SetResourceName("team4");
        images[5] = new MyImage();
        images[5].SetName("군침냥");
        images[5].SetResourceName("team5");
        images[6] = new MyImage();
        images[6].SetName("소파냥");
        images[6].SetResourceName("team6");
        images[7] = new MyImage();
        images[7].SetName("팝 캣");
        images[7].SetResourceName("team7");
    }
    void setEndPanel()
    {
        // 최단속도 설정
        if(PlayerPrefs.HasKey("fastest"))
        {
            if(PlayerPrefs.GetFloat("fastest") >= time)
            {
                PlayerPrefs.GetFloat("fastest", time);
                fastestTxt.text = time.ToString("N2");
            }
            else
            {
                fastestTxt.text = PlayerPrefs.GetFloat("fastest").ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.GetFloat("fastest", time);
            fastestTxt.text = time.ToString("N2");
        }
        // 이번 판 점수 설정
        float currentScore = 50f + (30f-time) - (float) tryCount/2; 
        currentScoreTxt.text = currentScore.ToString("N2");

        // 최고점 설정 <- 최단속도랑 똑같은데 key만 다름
        if(PlayerPrefs.HasKey("maxScore"))
        {
            if(PlayerPrefs.GetFloat("maxScore") <= currentScore)
            {
                PlayerPrefs.GetFloat("maxScore", currentScore);
                highScoreTxt.text = currentScore.ToString("N2");
            }
            else
            {
                highScoreTxt.text = PlayerPrefs.GetFloat("maxScore").ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.GetFloat("maxScore", time);
            highScoreTxt.text = currentScore.ToString("N2");
        }

    }
}