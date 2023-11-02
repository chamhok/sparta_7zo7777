using UnityEngine;

public class ProfileSetting
{
    public string name;
    public Sprite face;
    public string instruction;
    public string part;
    public ProfileSetting(string myName, Sprite myFace, string myPart, string myInst) // 이름, 프사, 직함, tmi
    {
        name = myName;
        part = myPart;
        instruction = myInst;
        face = myFace;
    }
}

// 카드프로필 팝업창에 더 넣고싶은게 있다면 변수 추가하고
// 갤러리매니저에서 관련 리소스 배열만들어 추가하기