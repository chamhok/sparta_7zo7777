using UnityEngine;

public class ProfileSetting
{
    public string name;
    public Sprite face;
    public string instruction;
    public string part;
    public ProfileSetting(string myName, Sprite myFace, string myPart, string myInst) // �̸�, ����, ����, tmi
    {
        name = myName;
        part = myPart;
        instruction = myInst;
        face = myFace;
    }
}

// ī�������� �˾�â�� �� �ְ������ �ִٸ� ���� �߰��ϰ�
// �������Ŵ������� ���� ���ҽ� �迭����� �߰��ϱ�