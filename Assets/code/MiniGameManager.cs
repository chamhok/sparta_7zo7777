using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MiniGameManager : MonoBehaviour
{
        public GameObject arrow;
        public GameObject run;
        public Text healthText;
        public Text timeTxt;
        public float currentTime = 0.0f;

        public arrow Arrow;
        public static MiniGameManager I;
        public float health;
        public float maxHealth = 100;
        public Animator anim;
    //bool isCharacterDead = false;

        // Start is called before the first frame update
        private void Awake()
        {
                Time.timeScale = 1.0f;
                I = this;
                health = maxHealth;
                InvokeRepeating("makeArrow", 0, 0.2f);

        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
                currentTime += Time.deltaTime;
                timeTxt.text = currentTime.ToString("N2");

                if (health > 0) 
                { 
                healthText.text = health.ToString(); 
                }
                else
                {
                        Time.timeScale = 0.0f;
                        healthText.text = "죽음!!!";
                }
                
        }
	/*IEnumerator CheckCharacterDeath()
    {
        while (true)
        {
            // 체력이 0이하일 때
            if (health <= 0)
            {
                isCharacterDead = true;
                anim.SetTrigger("die");
                yield return new WaitForSeconds(2); // 2초 기다리기
                SceneManager.LoadScene("MainScene");
                
            }
            
        }
    }//죽기, 죽을때 소리나기, 부활하기 
    */
	//화살을 생성
	void makeArrow()
        {
                Instantiate(arrow);
        }

}
