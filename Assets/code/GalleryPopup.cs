using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryPopup : MonoBehaviour
{

    public enum WhoIs // ������ ��ư enum�� ��� �Ȱ��ƾ��Ѵ�
    {
        ������,
        Ȳ����,
        ���ǿ�,
        ������,
        �ڱ���,
        ����
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
