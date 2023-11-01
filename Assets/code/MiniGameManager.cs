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
                        healthText.text = "����!!!";
                }
                
        }
    /*IEnumerator CheckCharacterDeath()
    {
        while (true)
        {
            // ü���� 0������ ��
            if (health <= 0)
            {
                isCharacterDead = true;
                anim.SetTrigger("die");
                yield return new WaitForSeconds(2); // 2�� ��ٸ���
                SceneManager.LoadScene("MainScene");
                
            }
            
        }
    }//�ױ�, ������ �Ҹ�����, ��Ȱ�ϱ� 
    */
    //ȭ���� ����
    void makeArrow()
        {
                Instantiate(arrow);
        }

}
