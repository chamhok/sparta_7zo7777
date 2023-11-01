using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
        public GameObject arrow;
        public GameObject run;
        public arrow Arrow;
        public static MiniGameManager I;
        // Start is called before the first frame update
        private void Awake()
        {
                InvokeRepeating("makeArrow", 0, 0.2f);

        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
        void makeArrow()
        {
                Instantiate(arrow);
        }

}
