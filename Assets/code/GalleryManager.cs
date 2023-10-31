using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static GalleryBtn;

public class GalleryManager : MonoBehaviour
{


    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    enum Achive { UnlockWoman, UnlockMan }
    Achive[] achives;
       
    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 1);
            /* 잠금해제하고 싶은 경우 윗줄에서 0을 1로 바꾼 뒤 
             * edit에서 Clear all PlayerPref를 눌러 초기화한 후 게임을 실행하면 잠금해제 
             */
        }
    }
   

    // 수집여부는 카드 두장 맞는지확인하는거에서 카드가 맞았을때 수집되지않은 카드라면 이펙트뜨고 수집한 카드면 그냥 들어감?


    // AudioSource audioSource;
    // Animator anim; // 게임매니저 애니메이터

    public GameObject popupObj;
    GalleryPopup[] galleryPopups; // 팝업창 애니메이터들

	/*
      
     * CG 종류만큼 갤러리 버튼 프리팹과 팝업창 프리팹을 컨트롤D로 늘리고 팝업창 내용을 수정해준다.
     * 
     * 팝업창과 버튼 ENUM에도 CG 이름 추가해야함. 나중에 CG 해금여부 읽을때도 필요
     
     */


	void Awake()
    {

        achives = (Achive[])Enum.GetValues(typeof(Achive));

        if (!PlayerPrefs.HasKey("MyData"))
        {
            Init();
        }
        //  anim = GetComponent<Animator>();
        //   audioSource = GetComponent<AudioSource>();
    }


    void Start()
    {
        UnlockCharacter();

        galleryPopups = new GalleryPopup[popupObj.transform.childCount];


        for (int i = 0; i < popupObj.transform.childCount; i++)
        {
            galleryPopups[i] = popupObj.transform.GetChild(i).gameObject.GetComponent<GalleryPopup>();
        }

    }
    void UnlockCharacter()
    {
        for (int index = 0; index < lockCharacter.Length; index++)
        {
            string achiveName = achives[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName, 0) == 1;
            // isUnlock = 1 :true
            lockCharacter[index].SetActive(!isUnlock);
            unlockCharacter[index].SetActive(isUnlock);

        }
    }

    public void PopupOpen(WhoIs name) // 팝업창열기. 자기 넘버 넣어서 실행. 넘버에맞는 팝업창 오픈된.
	{

        for (int i = 0; i < galleryPopups.Length; i++)
        {
            if ((int)galleryPopups[i].whoIs == (int)name)
            {
                galleryPopups[i].Open();
            }

        }

    }

}
