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
        public GameObject hurryUpPos;
        public GameObject hurryUp;
        public GameObject Hart;
        public GameObject drink;

        public Text healthText;
        public Text timeTxt;
        public Text youDieTxt;
        public Text scoreTxt;
        public Text DrinkingText;
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
                InvokeRepeating("makeDrink", 0, 3f);

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
                        youDieTxt.text = "";
                        healthText.text = health.ToString(); 
                }
                else
                {
                        gameOver();
                        healthText.text = "";
                        youDieTxt.text = "YOU DIE!";
                        Hart.SetActive(false);
                        
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

        GameObject hurry = Instantiate(hurryUp, trans.position, Quaternion.identity);
        hurry.transform.localScale = Vector3.one * 12f;
        }
        void makeArrow()
        {
                Instantiate(arrow);
        }
        void makeDrink()
        {
                Instantiate(drink);
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
