using UnityEngine;
using UnityEngine.UI;

public class GalleryBtn : MonoBehaviour
{
    public enum Achives
    {
        UnlockFirst,
        UnlockSecond,
        UnlockThird,
        UnlockFourth,
        UnlockFifth,
        UnlockSixth
    }
    public Achives achive; //업적이름 : 인스펙터에서 선택해주세요

    Sprite[] myKey;

    AudioSource audioSource;
    GalleryManager galleryManager;

    public GameObject lockCard; // Lock 이미지

    Button btn; // 버튼 컴포넌트


    public AudioClip flip;
    public AudioClip nya;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        btn = GetComponent<Button>();
        myKey = new Sprite[1];
    }

    void Start()
    {
        galleryManager = FindObjectOfType<GalleryManager>();
        lockCard.SetActive(true);
        btn.interactable = false; 

        Init();
        Set();
    }

    void Init()
    {
        audioSource.clip = flip;

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
                audioSource.clip = nya;

                break;

            default:
                Debug.Log("버그입니다!");
                break;
        }
    }

    void Set()
    {
        for (int i = 0; i < myKey.Length; i++)
        {
            if (!PlayerPrefs.HasKey(myKey[i].name)) // 플레이어프리프에 하나라도 안본 내사진이있다면 버튼 안열림
                return;
        }

        lockCard.SetActive(false);
        btn.interactable = true;
    }

    public void Click()
    {
        if (audioSource != null)
        audioSource.Play();

        galleryManager.PopupOpen((int)achive);
    }
}
