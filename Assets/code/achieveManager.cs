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
            //실제 실행되는지 실험해볼때는 0 => 1로 바꾼뒤 edit에 Clear All PlayerPref 클릭 후 실행
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
            //해금 조건이 달성되면 isUnlock = 1 :true
            lockCharacter[index].SetActive(!isUnlock);
            unlockCharacter[index].SetActive(isUnlock);

        }
    }

    void Update()
    {
        
    }
}
