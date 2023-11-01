using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static GalleryBtn;

public class GalleryBtn : MonoBehaviour
{
    GalleryManager.WhoIs whoIs;
    public enum Achives
    {
        UnlockFirst,
        UnlockSecond,
        UnlockThird,
        UnlockFourth,
        UnlockFifth,
        UnlockSixth
    }
    public Achives achive; //업적이름 인스펙터에서 선택해주세요


    Sprite[] myKey;

    AudioSource audioSource;
    GalleryManager galleryManager;

    public GameObject lockCard; // Lock 이미지
    public GameObject unLockCard; // UnLock 이미지

    Button btn; // 버튼 컴포넌트


    void Awake()
    {
        btn = GetComponent<Button>();
    }

    void Start()
    {
        galleryManager = FindObjectOfType<GalleryManager>();

        if (PlayerPrefs.HasKey("MyData"))
        {
            Init();
        }
        else
        {
            lockCard.SetActive(false);
            unLockCard.SetActive(true);
            btn.interactable = false;
        }
    }

    void Init()
    {
        switch (achive)
        {
            case Achives.UnlockFirst:
                myKey = galleryManager.firstKey;
                break;

            case Achives.UnlockSecond:
                myKey = galleryManager.secondKey;
                break;

            case Achives.UnlockThird:
                myKey = galleryManager.thirdKey;
                break;

            case Achives.UnlockFourth:
                myKey = galleryManager.fourthKey;
                break;

            case Achives.UnlockFifth:
                myKey = galleryManager.fifthKey;
                break;

            case Achives.UnlockSixth:
                myKey = galleryManager.sixthKey;
                break;

            default:
                Debug.Log("버그입니다!");
                break;
        }
<<<<<<< HEAD

        Set(achive);


=======
    }
    void Start()
    {
        string myResourceName = gameObject.transform.Find("unlocked").GetComponent<Image>().sprite.name;
        Debug.Log(myResourceName);
        Debug.Log(PlayerPrefs.HasKey(myResourceName));
        UnlockCharacter();
>>>>>>> 67aed5e26b0be7462d6c0cfec259105ff04b5d53
    }

    void Set(Achives ach)
    {
        for (int i = 0; i < myKey.Length; i++)
        {
            if (!PlayerPrefs.HasKey(myKey[i].name)) // 플레이어프리프에 내사진 해금이 전부 됐을때 버튼  on
            {
                Debug.Log("버튼 닫힙니다");
                unLockCard.SetActive(true);
                lockCard.SetActive(false);
                btn.interactable = false;
                return;
            }
        }

        unLockCard.SetActive(false);
        lockCard.SetActive(true);
        btn.interactable = true;

        Debug.Log("버튼 해금됐습니다");

    }

    public void Click()
    {
        Debug.Log("실행됨");

        if (audioSource != null)
            audioSource.Play();

        galleryManager.PopupOpen((int)achive);
    }
<<<<<<< HEAD

}
=======
}
    
    /*void LateUpdate()
    {
        foreach (Achive achive in achives)
        {
            CheckAchive(achive);
        }
    }
    void CheckAchive(Achive achive)
    {
        bool isAchive = false;
        GameObject[] LockCardImage;
        FirstCardImage = PlayerPrefs.GetString("Canvas/Scroll view/Viewpoint/Content/Gallery");
        LockCardImage = GameObject.FindGameObjectsWithTag("GalleryBtn");
        
        switch (achive)
        {
            case Achive.UnlockFirst:
                isAchive = false; // 초기화
                foreach (GameObject cardImage in LockCardImage)
                {
                    if (cardImage.name == FirstCardImage)
                    {
                        isAchive = true;
                        break;
                    }
                }
                break;

            case Achive.UnlockSecond:
                isAchive = false; // 초기화
                foreach (GameObject cardImage in LockCardImage)
                {
                    if (cardImage.name == "황선범")
                    {
                        isAchive = true;
                        break;
                    }
                }                
                break;

            case Achive.UnlockThird:
                isAchive = false; // 초기화
                foreach (GameObject cardImage in LockCardImage)
                {
                    if (cardImage.name == "강건욱")
                    {
                        isAchive = true;
                        break;
                    }
                }                
                break;

            case Achive.UnlockFourth:
                isAchive = false; // 초기화
                foreach (GameObject cardImage in LockCardImage)
                {
                    if (cardImage.name == "정용태")
                    {
                        isAchive = true;
                        break;
                    }
                }                                
                break;

            case Achive.UnlockFifth:
                isAchive = false; // 초기화
                foreach (GameObject cardImage in LockCardImage)
                {
                    if (cardImage.name == "박기혁")
                    {
                        isAchive = true;
                        break;
                    }
                }                
                break;

            case Achive.UnlockSixth:
                isAchive = false; // 초기화
                foreach (GameObject cardImage in LockCardImage)
                {
                    if (cardImage.name == "군침냥")
                    {
                        isAchive = true;
                        break;
                    }
                }                
                break;
                
        }
        if (isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0)
        {
            PlayerPrefs.SetInt(achive.ToString(), 1);
        }
    }
*/
>>>>>>> 67aed5e26b0be7462d6c0cfec259105ff04b5d53
