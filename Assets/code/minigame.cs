using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigame : MonoBehaviour
{
        public Vector2 inputVec;
        Rigidbody2D rigid;
        public float speed;
        // Start is called before the first frame update
        void Start()
        {
                rigid = GetComponent<Rigidbody2D>();
                
        }

        // Update is called once per frame
        void Update()
        {
                inputVec.x = Input.GetAxis("Horizontal");
                inputVec.y = Input.GetAxis("Vertical");
        }
        private void FixedUpdate()
        {
                Debug.Log(Mathf.Abs(transform.position.y));
                float scale = 180 / Mathf.Abs(transform.position.y);
               if (transform.position.y < -275) transform.position = new Vector3(transform.position.x, -275, 0);
                
                transform.localScale = new Vector3(scale, scale, 1);
                Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
                rigid.MovePosition(rigid.position + inputVec);
        }
}
