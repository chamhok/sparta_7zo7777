using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static GalleryBtn;

public class GalleryManager : MonoBehaviour
{



    // �������δ� ī�� ���� �´���Ȯ���ϴ°ſ��� ī�尡 �¾����� ������������ ī���� ����Ʈ�߰� ������ ī��� �׳� ��?


   // AudioSource audioSource;
   // Animator anim; // ���ӸŴ��� �ִϸ�����


    public GameObject popupObj;
    GalleryPopup[] galleryPopups; // �˾�â �ִϸ����͵�



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

    public void PopupOpen(WhoIs name) // �˾�â����. �ڱ� �ѹ� �־ ����. �ѹ����´� �˾�â ���µ�.
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
