using UnityEngine;

public class GalleryPopup : MonoBehaviour
{
     Animator anim;

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
