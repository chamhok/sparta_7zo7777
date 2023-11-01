using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

        Set(achive);
    }

    void Set(Achives ach)
    {
        for (int i = 0; i < myKey.Length; i++)
        {
            if (!PlayerPrefs.HasKey(myKey[i].name)) // 플레이어프리프에 하나라도 안본 내사진이있다면 버튼 안열림
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
}
    