using UnityEngine;

public class GalleryPopup : MonoBehaviour
{
    Animator anim;
    public Animator ssrAnim;

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
        ssrAnim.SetBool("isOpen", false);
    }

    public void OpenSSRver()
    {
        anim.SetTrigger("Open");
        ssrAnim.SetBool("isOpen", true);

    }

}
