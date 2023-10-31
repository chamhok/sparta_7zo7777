using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GalleryBtn : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public int num; // cg번호
    bool isGet = false; // 이 cg를 얻었는지


    public Sprite backSprite; // cg 해금안됐을때 뜨는 뒷면 이미지

    Image img;
    Animator anim;
    AudioSource audioSource;
    GalleryManager galleryManager;


    void Awake()
    {
        img = GetComponent<Image>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        galleryManager = FindObjectOfType<GalleryManager>();
    }


    private void OnEnable()
    {
        // 플레이어프리프에 카드 획득여부읽고 넣기

        if (!isGet)
        {
            img.sprite = backSprite;
        }

        anim.SetBool("isGet", isGet);
        anim.SetTrigger("go");

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null) { }
        // audioSource.Play(); 엔터사운드로 교체

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (audioSource != null)
            audioSource.Play();


        galleryManager.PopupOpen(num);

        Debug.Log(num + "번 cg열립니다");

    }


}
