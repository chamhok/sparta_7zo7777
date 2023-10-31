using UnityEngine;

public class ProfileSetting
{
    public string name;
    public Sprite face;
    public string instruction;

    public ProfileSetting(string myName, Sprite myFace, string myInst) // 이름, 프사, tmi
    {
        name = myName;
        instruction = myInst;
        face = myFace;
    }
}
