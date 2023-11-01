using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniGameManager : MonoBehaviour
{
        public GameObject arrow;
        public GameObject run;
        public Text healthText;
        public arrow Arrow;
        public static MiniGameManager I;
        public float health;
        public float maxHealth = 100;
        // Start is called before the first frame update
        private void Awake()
        {
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
                if (health > 0) healthText.text = health.ToString();
                else healthText.text = "죽음!!!";
        }

        //화살을 생성
        void makeArrow()
        {
                Instantiate(arrow);
        }

}
