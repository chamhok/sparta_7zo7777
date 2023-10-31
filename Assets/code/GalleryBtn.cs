using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GalleryBtn : MonoBehaviour, IPointerEnterHandler
{

    public enum WhoIs // ������ �˾� enum�� ��� �Ȱ��ƾ��Ѵ�
    {
        ������,
        Ȳ����,
        ���ǿ�,
        ������,
        �ڱ���,
        ����
    }

    public WhoIs whoIs;



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
      

        if (false)   // �÷��̾��������� ī�� ȹ�濩�� �ֱ�
        {
            img.sprite = backSprite;
        }

        anim.SetBool("isGet", false); // �÷��̾��������� ī�� ȹ�濩�� �ֱ�
        anim.SetTrigger("go");

    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null) { }
        // audioSource.Play(); ���ͻ���� ��ü

    }

    public void Click()
    {
        if (audioSource != null)
            audioSource.Play();


        galleryManager.PopupOpen(whoIs);

        Debug.Log(whoIs + "�� cg�����ϴ�");

    }


}
