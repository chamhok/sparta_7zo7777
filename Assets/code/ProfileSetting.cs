using UnityEngine;

public class ProfileSetting
{
    public string name;
    public Sprite face;
    public string instruction;

    public ProfileSetting(string myName, Sprite myFace, string myInst) // �̸�, ����, tmi
    {
        name = myName;
        instruction = myInst;
        face = myFace;
    }
}
