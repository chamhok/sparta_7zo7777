using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryPopup : MonoBehaviour
{

    public enum WhoIs // 갤러리 버튼 enum과 목록 똑같아야한다
    {
        전은하,
        황선범,
        강건욱,
        정용태,
        박기혁,
        냥이
    }

    public WhoIs whoIs;


    [HideInInspector] public Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        anim.SetTrigger("Open");
    }

    public void Close()
    {
        anim.SetTrigger("Close");

    }
}
