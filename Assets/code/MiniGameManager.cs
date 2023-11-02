﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MiniGameManager : MonoBehaviour
{
        public GameObject arrow;
        public GameObject run;
        public GameObject retryBtn;
        public GameObject hurryUpPos;
        public GameObject hurryUp;
        public Text healthText;
        public Text timeTxt;
        public Text scoreTxt;
        public float currentTime = 0.0f;
        

        public arrow Arrow;
        public static MiniGameManager I;
        public float health;
        public float maxHealth = 100;
        public Animator anim;
        public float level = 1f;
        public int levelCount = 0;
        public float[] nextTime = { 5f, 10f, 15f, 20f, 25f, 30f, 35f, 40f, 60f, 100f, 150f, 210f, 280f, 360f, 450f, 600f };


        //bool isCharacterDead = false;

        private void Awake()
        {
                scoreTxt.text = "BestScore " + PlayerPrefs.GetFloat("bestScore").ToString("N2");
                anim = GetComponent<Animator>();
                Time.timeScale = 1.0f;
                I = this;
                health = maxHealth;
                InvokeRepeating("makeArrow", 0, 0.1f);

        }
       

        void Update()
        {
                // if (isCharacterDead) return;
                currentTime += Time.deltaTime;
                timeTxt.text = currentTime.ToString("N2");
                if (currentTime > nextTime[levelCount])
                {
                        levelUp();
                }
                        if (health > 0) 
                { 
                        healthText.text = health.ToString(); 
                }
                else

                {
                        gameOver();
                        
                        healthText.text = "DIE";
                }
                
                
        }
        public void levelUp()
        {
                levelCount++;
                Debug.Log(levelCount);
                generateEffect_HurryUp(hurryUpPos.transform);
        }
        public void generateEffect_HurryUp(Transform trans)
        {
                Instantiate(hurryUp, trans.position, Quaternion.identity);
        }
        void makeArrow()
        {
                Instantiate(arrow);
        }
     
        public void gameOver()
        {
                
                
                retryBtn.SetActive(true);
                
                if (PlayerPrefs.HasKey("bestScore") == false)
                {
                        PlayerPrefs.SetFloat("bestScore", currentTime);
                        scoreTxt.text = "BestScore " + PlayerPrefs.GetFloat("bestScore").ToString("N2");

                }
                else
                {
                        if (PlayerPrefs.GetFloat("bestScore") < currentTime)
                        {
                                PlayerPrefs.SetFloat("bestScore", currentTime);
                                scoreTxt.text = "BestScore " + PlayerPrefs.GetFloat("bestScore").ToString("N2");

                        }
                }
        }

}
