using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GalleryBtn : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public int num; // cg��ȣ
    bool isGet = false; // �� cg�� �������


    public Sprite backSprite; // cg �رݾȵ����� �ߴ� �޸� �̹���

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
        // �÷��̾��������� ī�� ȹ�濩���а� �ֱ�

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
        // audioSource.Play(); ���ͻ���� ��ü

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (audioSource != null)
            audioSource.Play();


        galleryManager.PopupOpen(num);

        Debug.Log(num + "�� cg�����ϴ�");

    }


}
