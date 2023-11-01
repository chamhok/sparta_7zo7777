using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MiniGameManager : MonoBehaviour
{
        public GameObject arrow;
        public GameObject run;
        public GameObject retryBtn;
        public Text healthText;
        public Text timeTxt;
        public float currentTime = 0.0f;

        public arrow Arrow;
        public static MiniGameManager I;
        public float health;
        public float maxHealth = 100;
        public Animator anim;
        public float level = 1f;
        public float[] nextTime = { 5f, 10f, 15f, 20f, 25f, 30f, 35f, 40f, 60f, 100f, 150f, 210f, 280f, 360f, 450f, 600f };


        //bool isCharacterDead = false;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            Time.timeScale = 1.0f;
                I = this;
                health = maxHealth;
                InvokeRepeating("makeArrow", 0, 0.1f);

        }
        void Start()
        {
        }

        void Update()
        {
                // if (isCharacterDead) return;
                currentTime += Time.deltaTime;
                timeTxt.text = currentTime.ToString("N2");
                
                if (health > 0) 
                { 
                        healthText.text = health.ToString(); 
                }
                else

                {
                        retryBtn.SetActive(true);
                        Time.timeScale = 0.0f;
                        healthText.text = "YOU DIED!!!";
                }
                
        }
	//ȭ�� ���
	void makeArrow()
        {
                Instantiate(arrow);
        }

}
