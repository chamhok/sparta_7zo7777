using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public enum WhoIs
    {
        전은하,
        황선범,
        강건욱,
        정용태,
        박기혁,
        냥이
    }

    public Sprite[] faces; // enum의 순서대로 프사를 넣어주세요.
    public string[] tmis; // enum의 순서대로 설명을 적어주세요.

    public Text nameTxt;
    public Image faceImg;
    public Text tmiTxt;

    public GalleryPopup galleryPopup;
    private Dictionary<int, ProfileSetting> profile;

    void Awake()
    {
        profile = new Dictionary<int, ProfileSetting>();

        for (int i = 0; i < Enum.GetValues(typeof(WhoIs)).Length; i++)
        {
            profile.Add(i, new ProfileSetting(((WhoIs)(i)).ToString(), faces[i], tmis[i]));
        }
    }

    public void PopupOpen(int num)
    {
        nameTxt.text = profile[num].name;
        tmiTxt.text = profile[num].instruction;
        faceImg.sprite = faces[num];

        galleryPopup.Open();
    }
}
