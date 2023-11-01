using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigame : MonoBehaviour
{
        public Vector2 inputVec;
        Rigidbody2D rigid;
        public float speed;
        float stendingPos;
        public Animator anim;
       // WaitForFixedUpdate wait; 작동안됨

        void Start()
        {
                stendingPos = Mathf.Abs(transform.position.y);
                rigid = GetComponent<Rigidbody2D>();
                anim = GetComponent<Animator>();
               // wait = new WaitForFixedUpdate();
                
        }

        void Update()
        {
                inputVec.x = Input.GetAxis("Horizontal");
                inputVec.y = Input.GetAxis("Vertical");
        }
        //미니게임 플레이어를 이동시킨다.
        private void FixedUpdate()
        {
              //  if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit")) return; 작동안됨 
                float scale = Mathf.Abs(transform.position.y) / stendingPos;
                transform.localScale = new Vector3(scale, scale, 1);
                Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
                rigid.MovePosition(rigid.position + inputVec);
        }
        void OnCollisionEnter2D(Collision2D coll)
        {
                if (coll.gameObject.tag == "arrow")
                {
                        transform.position = new Vector3(transform.position.x - 5f, transform.position.y, 0); //화살에 맞으면 뒤로 이동 시킴
                       // StartCoroutine(knockBoack()); 작동안됨 
                      //  anim.SetTrigger("hit");
                }
        }
        /* 작동안됨 
        IEnumerator knockBoack()
        {
                yield return wait;
                Vector3 dirVec = transform.position - transform.position;
                rigid.AddForce(dirVec.normalized*3 , ForceMode2D.Impulse);
        }
        */
}
