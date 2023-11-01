using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.SocialPlatforms.Impl;
using System.Threading;

class MyImage
{
    string name;
    string resourceName;
    bool isCat = false;

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
    public bool GetIsCat()
    {
        return this.isCat;
    }
	public void SetIsCat(bool isCat)
	{
		this.isCat = isCat;
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
    public AudioClip matchCat;

    public Text fastestTxt;
    public Text currentScoreTxt;
    public Text highScoreTxt;
    public Text timeTxt;
    public Text tryTxt;
    public Text matchTxt;
    public Text matchingTxt;

    public GameObject endPanel;

    public GameObject card;
    public GameObject cards;
    public GameObject matchFailTxt;

    public static gameManager I;

    public GameObject firstCard;
    public GameObject secondCard;

    public float limitTime = 5.0f;
    public int difficult = 0;
    float currentTime = 0.0f;
    float matchFailScore = 1f;
	int tryCount = 0;
    int matchingCount = 0;

    // 현재는 수동으로 배열의 갯수와 setImages 함수를 바꿔야 한다.
    // 차후에 스크립트(card.cs)에 변수를 할당하는 방식으로 고칠 수 있다.
    MyImage[] images = new MyImage[20];

    int cardStocks = 0;
    int cardsLeft = 0;
	List<int> catList = new List<int>();
    string catName;

	bool isEnd = false;
    bool isHurry = false;
    bool[] check = new bool[0];
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
        difficult = GameObject.Find("difficultysend").GetComponent<difficultysend>().difficult;
        currentTime = limitTime;
        isEnd = false;
        isHurry = false;
        cardStocks = 4*(3+difficult);
        // 자리가 남아있는지 확인하는 변수
        cardsLeft = cardStocks;
        check = new bool[cardStocks];

		for (int i = 0; i < cardStocks; i++)
		{
			check[i] = false;
		}
		Time.timeScale = 1.0f;

        audioSource.clip = bgmusic;
        audioSource.Play();//bgm 재생
        setImages();
		generateCard(chooseCat());
        separteCats();
		shuffleImages(images);

        // 카드갯수/2 - 1만큼 반복한다.
        for (int i = 0; i < (cardStocks/2 - 1); i++)
        {
            generateCard(i);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd) return;

        currentTime -= Time.deltaTime;
        timeTxt.text = currentTime.ToString("N2");
                
        //제한시간이 지나면 게임 종료
        if (currentTime <= 0)
        {
            isEnd = true;
            gameEnd(false);
            audioSource.clip = bgmusic;
            audioSource.Pause();
            audioSource.clip = defeat;
            audioSource.Play();
            //30초 지나면 실패 음악으로 변경
        }
        else if (currentTime < 10.0f && !isHurry)
        {
            isHurry = true;
            timeTxtAnim.SetTrigger("isHurryUp");
        }
    }
    

    // 카드의 뒤집는 횟수를 센다.
    private void tryCounting()
    {
        tryCount++;
        tryTxt.text = tryCount + "번 시도함!";
     }
        
    // 카드의 매칭 횟수를 센다.
    private void MachingCounting()
    {
        matchingCount++;
        matchingTxt.text = matchingCount + "번 맞춤!";
    }
    public void isMatched()
    {
        tryCounting();
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            MachingCounting();
            if (firstCard.transform.name == catName)
                audioSource.PlayOneShot(matchCat);
            else
                audioSource.PlayOneShot(match);
            cardsLeft -= 2;
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
            setMatchTxt(setTxt(firstCardImage));
            addGallery(firstCardImage);
			if (cardsLeft == 0)
            {
                // 게임종료, endpanel 활성화 + 점수 계산
                gameEnd(true);
                
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
                generateFailTxt(matchFailScore);
                currentTime -= matchFailScore;
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
        if (catName == firstCard.transform.name)
		{
            int rand = Random.Range(0,cards.transform.childCount-1);
			Vector3 tempPosition = firstCard.transform.position;
			firstCard.transform.position = cards.transform.GetChild(rand).position;
			cards.transform.GetChild(rand).position = tempPosition;
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

    void separteCats()
    {
		int tempLimit = images.Length - 1 - catList.Count;
		int count = images.Length - 1;

		for (int i = 0; i < tempLimit; i++)
		{
            while (images[count].GetIsCat()) count--;
            if (images[i].GetIsCat())
            {
                MyImage temp;
                temp = images[i];
                images[i] = images[count];
                images[count] = temp;
            }
		}
	}

    // class의 배열을 랜덤하게 섞는 함수(인터넷에서 봄)
    MyImage[] shuffleImages(MyImage[] list)
    {
        int random1,  random2;
        MyImage temp;

        for (int i = 0; i < list.Length - catList.Count; ++i)
        {
            // 맨 뒤에 고양이가 들어있는 배열들은 제외
            random1 = Random.Range(0, list.Length - catList.Count);
            random2 = Random.Range(0, list.Length - catList.Count);

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

        // 해당 for문의 조건문은 수동으로 바꿔야 함 (개선 필요!)
        for(int i=0; i< 20; i++)
        {
            images[i] = new MyImage();
            images[i].SetResourceName("team" + i.ToString());
        }

        images[0].SetName("황선범");
        images[1].SetName("전은하");
        images[2].SetName("박기혁");
        images[3].SetName("정용태");
        images[4].SetName("강건욱");
        images[5].SetName("군침냥");
		images[5].SetIsCat(true);
        images[6].SetName("소파냥");
		images[6].SetIsCat(true);
        images[7].SetName("팝 캣");
		images[7].SetIsCat(true);
		images[8].SetName("전은하");
		images[9].SetName("박기혁");
		images[10].SetName("전은하");
		images[11].SetName("강건욱");
		images[12].SetName("강건욱");
		images[13].SetName("황선범");
		images[14].SetName("세븐");
		images[15].SetName("정용태");
		images[16].SetName("박기혁");
		images[17].SetName("세븐");
		images[18].SetName("박기혁");
		images[19].SetName("고양이");
        images[19].SetIsCat(true);
	}
    void gameEnd(bool success)
    {
		endPanel.SetActive(true);
		Time.timeScale = 0.0f;
        // 몇 초 안에 깼는지
        float clearTime = limitTime - currentTime; // 남은시간
        float timeScore = currentTime;
        if(success) // 게임 승리!
        {
			if (PlayerPrefs.HasKey("fastest"))
			{
				if (PlayerPrefs.GetFloat("fastest") <= clearTime)
				{
					PlayerPrefs.SetFloat("fastest", clearTime);
					fastestTxt.text = clearTime.ToString("N2");
				}
				else
				{
					fastestTxt.text = PlayerPrefs.GetFloat("fastest").ToString("N2");
				}
			}
			else // 키가 없으면
			{
				PlayerPrefs.SetFloat("fastest", clearTime);
				fastestTxt.text = clearTime.ToString("N2");
			}
		}
        else // 게임 패배
        {
            if (PlayerPrefs.HasKey("fastest"))
            {
                fastestTxt.text = PlayerPrefs.GetFloat("fastest").ToString("N2");
            }
            else // 키가 없으면
            {
                fastestTxt.text = "0.00";
            }
		}

        // 이번 판 점수 설정
        float currentScore = 0f;
        if(success) currentScore = 50f + timeScore - (float)tryCount / 2;
        if(currentScore < 0) currentScore = 0;
		currentScoreTxt.text = currentScore.ToString("N2");

        // 최고점 설정 <- 최단속도랑 똑같은데 key만 다름
        if(PlayerPrefs.HasKey("maxScore"))
        {
            if(PlayerPrefs.GetFloat("maxScore") <= currentScore)
            {
                PlayerPrefs.SetFloat("maxScore", currentScore);
                highScoreTxt.text = currentScore.ToString("N2");
            }
            else
            {
                highScoreTxt.text = PlayerPrefs.GetFloat("maxScore").ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat("maxScore", currentScore);
            highScoreTxt.text = currentScore.ToString("N2");
        }

    }

	int chooseCat()
	{
		// 사진에서 고양이만 찾은 다음 거기에서 하나 선택 -> 숫자 return
		for (int i = 0; i < images.Length; i++)
		{
			if (images[i].GetIsCat()) catList.Add(i);
		}
        int temp = Random.Range(0, catList.Count);
        catName = images[catList[temp]].GetName();
		return catList[temp];
	}

    void generateCard(int i)
    {
		int doubleCheck = 0;
		while (true)
		{
			int rand = Random.Range(0, cardStocks);
			if (check[rand] == false)
			{
				check[rand] = true;
				GameObject newCard = Instantiate(card);
				newCard.transform.parent = GameObject.Find("cards").transform;
				float x = (rand % 4) * 1.4f - 2.1f;
                float y = -(rand / 4) * 1.4f + (0.8f + 0.4f * difficult);
				newCard.transform.position = new Vector3(x, y, 0);
				newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(images[i].GetResourceName());
				newCard.transform.name = images[i].GetName(); // 카드에게 각각 이름을 부여
				doubleCheck++;
			}
			if (doubleCheck >= 2)
			{
				doubleCheck = 0;
				break;
			}
		}
	}

    void addGallery(string resourceName)
    {
		// playerprefs에 리소스명을 저장 -> gallery Scene에서 이용할 수 있도록
        if(PlayerPrefs.HasKey(resourceName))
        {
            return;
        }
        else
        {
            PlayerPrefs.SetInt(resourceName, 1);
        }
	}

    void generateFailTxt(float matchFailScore)
    {
        GameObject newTxt = Instantiate(matchFailTxt, GameObject.Find("Canvas").transform);
        newTxt.GetComponent<matchFailTxt>().setMyTxt(matchFailScore);
    }

}