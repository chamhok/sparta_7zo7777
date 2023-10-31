using UnityEngine;
using UnityEngine.UI;

public class GalleryBtn : MonoBehaviour
{
    public GalleryManager.WhoIs whoIs;

    AudioSource audioSource;
    GalleryManager galleryManager;

    public GameObject blindObj;

    Button btn;

    void Awake()
    {
        btn = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        galleryManager = FindObjectOfType<GalleryManager>();
    }


    private void OnEnable() // 임시로 랜덤 획득중
    {
        int a = Random.Range(0, 2);
        blindObj.SetActive((a == 0));
        btn.interactable = !(a == 0);
        // 이 버튼이 누구 버튼인지(int)whoIs, 그 사람의 카드를 획득했는지 플레이어프리프 이용해서 false에 넣기
    }

    public void Click()
    {
        if (audioSource != null)
            audioSource.Play();

        galleryManager.PopupOpen((int)whoIs);
    }
}


/*
 

/*
     void UnlockCharacter()
    {
        for (int index = 0; index < lockCharacter.Length; index++)
        {
            string achiveName = achives[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName, 0) == 1;
            // isUnlock = 1 :true
            lockCharacter[index].SetActive(!isUnlock);
            unlockCharacter[index].SetActive(isUnlock);

        }
    }



   void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 1);
            /* 잠금해제하고 싶은 경우 윗줄에서 0을 1로 바꾼 뒤 
             * edit에서 Clear all PlayerPref를 눌러 초기화한 후 게임을 실행하면 잠금해제 
             */
