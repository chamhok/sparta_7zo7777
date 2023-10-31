using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achieveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    enum Achive { UnlockWoman, UnlockMan }
    Achive[] achives;

    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive));

        if (!PlayerPrefs.HasKey("MyData"))
        {
            Init();
        }
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach(Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
            //���� ����Ǵ��� �����غ����� 0 => 1�� �ٲ۵� edit�� Clear All PlayerPref Ŭ�� �� ����
        }
    }
    void Start()
    {
        UnlockCharacter();
    }

    void UnlockCharacter()
    {
        for(int index=0; index < lockCharacter.Length; index++)
        {
            string achiveName = achives[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName, 0) == 1;
            //�ر� ������ �޼��Ǹ� isUnlock = 1 :true
            lockCharacter[index].SetActive(!isUnlock);
            unlockCharacter[index].SetActive(isUnlock);

        }
    }

    void Update()
    {
        
    }
}
