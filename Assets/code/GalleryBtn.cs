using System;
using Unity.Burst.CompilerServices;
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

    public GameObject LockCard; // Lock 이미지
    public GameObject UnLockCard; // UnLock 이미지

    Button btn; // 버튼 컴포넌트

    void Awake()
    {
        btn = GetComponent<Button>();
       

        galleryManager = FindObjectOfType<GalleryManager>();
        whoIs = (WhoIs[])Enum.GetValues(typeof(WhoIs));

        if (!PlayerPrefs.HasKey("MyData"))
            Init();
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach (WhoIs card in whoIs)
        {
            PlayerPrefs.SetInt(card.ToString() + "IsGet", 0);
        }
    }

    private void OnEnable()
    {
        int isCardGet = PlayerPrefs.GetInt(gameObject.name + "IsGet", 0);

        if (isCardGet != 0)
        {
            btn.interactable = true; // 버튼을 상호 작용 가능하게 설정
            LockCard.SetActive(false); // Lock 이미지를 비활성화
            UnLockCard.SetActive(true); // UnLock 이미지를 활성화
        }
        else
        {
            btn.interactable = false; // 버튼을 상호 작용 불가능하게 설정
            LockCard.SetActive(true); // Lock 이미지를 활성화
            UnLockCard.SetActive(false); // UnLock 이미지를 비활성화
        }
    }

    public void Click()
    {
        if (audioSource != null)
            audioSource.Play();

        int whoIsIndex = Array.IndexOf(whoIs, (WhoIs)Enum.Parse(typeof(WhoIs), gameObject.name));

        galleryManager.PopupOpen(whoIsIndex);

        PlayerPrefs.SetInt(gameObject.name + "IsGet", 1);
        PlayerPrefs.Save();
    }
}

