using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static GalleryBtn;

public class GalleryManager : MonoBehaviour
{



    // 수집여부는 카드 두장 맞는지확인하는거에서 카드가 맞았을때 수집되지않은 카드라면 이펙트뜨고 수집한 카드면 그냥 들어감?


   // AudioSource audioSource;
   // Animator anim; // 게임매니저 애니메이터


    public GameObject popupObj;
    GalleryPopup[] galleryPopups; // 팝업창 애니메이터들



    void Awake()
    {

      //  anim = GetComponent<Animator>();
     //   audioSource = GetComponent<AudioSource>();
    }


    void Start()
    {

        galleryPopups = new GalleryPopup[popupObj.transform.childCount];


        for (int i = 0; i < popupObj.transform.childCount; i++)
        {
            galleryPopups[i] = popupObj.transform.GetChild(i).gameObject.GetComponent<GalleryPopup>();
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
