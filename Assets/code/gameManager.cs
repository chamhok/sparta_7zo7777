using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public Text tryTxt;
    float time = 0.0f;

    public GameObject endTxt;
    int tryCount = 0;
    public GameObject card;

    public static gameManager I;

    public GameObject firstCard;
    public GameObject secondCard;



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
        isEnd = false;
        isHurry = false;



        Time.timeScale = 1.0f;

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
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

            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
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
        tryTxt.text = tryCount + "¹ø";
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }
}