using System;
using System.Reflection;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static GalleryManager;

public class GalleryBtn : MonoBehaviour
{
    public enum WhoIs
    {
        전은하,
        황선범,
        강건욱,
        정용태,
        박기혁,
        냥이
    }
    WhoIs[] whoIs;

    AudioSource audioSource;
    GalleryManager galleryManager;

    public GameObject[] LockCard; // Lock 이미지
    public GameObject[] UnLockCard; // UnLock 이미지
    public int BtnNumber = 0;
    public string FirstCardImage;

    Button btn; // 버튼 컴포넌트
    enum Achive { UnlockFirst, UnlockSecond, UnlockThird, UnlockFourth, UnlockFifth, UnlockSixth }
    Achive[] achives;

    void Awake()
    {
        btn = GetComponent<Button>();


        galleryManager = FindObjectOfType<GalleryManager>();
        achives = (Achive[])Enum.GetValues(typeof(Achive));

        if (!PlayerPrefs.HasKey("MyData")) //HasKey함수로 데이터 유무 체크 후 초기화 실행
        {
            Init();
        }

    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }
    }
    void Start()
    {
        UnlockCharacter();
    }

    void UnlockCharacter()
    {
        for (int index = 0; index < LockCard.Length; index++)
        //잠금 버튼 배열을 순회하면서 인덱스에 해당하는 업적 이름 가져오기
        {
            string achiveName = achives[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
            //GetInt함수로 저장된 업적 상태를 가져와서 버튼 활성화에 적용
            LockCard[index].SetActive(!isUnlock); //부정이기 때문에 !사용
            UnLockCard[index].SetActive(isUnlock);
        }
    }



    public void Click()
    {
        if (audioSource != null)
            audioSource.Play();

        int whoIsIndex = Array.IndexOf(whoIs, (WhoIs)Enum.Parse(typeof(WhoIs), gameObject.name));

        galleryManager.PopupOpen(whoIsIndex);
    }

    void LateUpdate()
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
}