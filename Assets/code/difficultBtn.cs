using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultBtn : MonoBehaviour
{
    public AudioClip click;
    public AudioSource audioSource;

    public Text difficultTxt;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void difficultUp()
    {
        difficulty++;
        difficultconfirm();
    }

    public void difficultDown()
    {
        difficulty--;
        difficultconfirm();
    }

    void difficultconfirm()
    {
        if (difficulty < 0)
        {
            difficulty = 2;
        }
        if (difficulty > 2)
        {
            difficulty = 0;
        }

        if (difficulty == 0)
        {
            difficultTxt.text = "쉬움";
        }
        else if (difficulty == 1)
        {
            difficultTxt.text = "보통";
        }
        else if (difficulty == 2)
        {
            difficultTxt.text = "어려움";
        }
        GameObject.Find("difficultysend").GetComponent<difficultysend>().difficult = difficulty;
    }
}
