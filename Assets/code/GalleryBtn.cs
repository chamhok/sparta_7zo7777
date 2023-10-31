using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GalleryBtn : MonoBehaviour, IPointerEnterHandler
{

    public enum WhoIs // 갤러리 팝업 enum과 목록 똑같아야한다
    {
        전은하,
        황선범,
        강건욱,
        정용태,
        박기혁,
        냥이
    }

    public WhoIs whoIs;

    Animator anim;
    AudioSource audioSource;
    GalleryManager galleryManager;


    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        galleryManager = FindObjectOfType<GalleryManager>();
    }


    private void OnEnable()
    {
        anim.SetBool("isGet", false); // 플레이어프리프에 카드 획득여부 넣기
        anim.SetTrigger("go");
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
       // if (audioSource != null)
         //  audioSource.Play();  // 엔터사운드로 교체
    }

    public void Click()
    {
        if (audioSource != null)
            audioSource.Play();

        galleryManager.PopupOpen(whoIs);

        Debug.Log(whoIs + " cg열립니다");

    }


}
