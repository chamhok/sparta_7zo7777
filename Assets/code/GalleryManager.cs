using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    // Resources폴더 속 team 이미지를 배열에 넣어주세요. (순서상관없음, 실수로 중복넣어도 가능!)
 
    public Sprite[] firstKey; //전은하
    public Sprite[] secondKey; // 황선범
    public Sprite[] thirdKey; // 강건욱
    public Sprite[] fourthKey; // 정용태
    public Sprite[] fifthKey; // 박기혁
    public Sprite[] sixthKey; //냥이

    //---------------------------------------------------------


    readonly string[] names = { "전은하", "황선범", "강건욱", "정용태", "박기혁", "냥이" };
    public Sprite[] faces; // 이름 순서대로 프사를 넣어주세요.
    [TextArea]
    public string[] tmis; // 이름 순서대로 설명을 적어주세요.

    public Text nameTxt;
    public Image faceImg;
    public Text tmiTxt;

    public GalleryPopup galleryPopup;
    private Dictionary<int, ProfileSetting> profile;

    void Awake()
    {
        profile = new Dictionary<int, ProfileSetting>();

        for (int i = 0; i < names.Length; i++)
        {
            profile.Add(i, new ProfileSetting(names[i], faces[i], tmis[i]));
        }
    }

    public void PopupOpen(int num)
    {
        nameTxt.text = profile[num].name;
        tmiTxt.text = profile[num].instruction;
        faceImg.sprite = faces[num];

        if (num == 5) // 냥이는 ssr배경
            galleryPopup.OpenSSRver();
        else
            galleryPopup.Open();
    }
}
