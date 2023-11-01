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
       // WaitForFixedUpdate wait;

        // Start is called before the first frame update
        void Start()
        {
                stendingPos = Mathf.Abs(transform.position.y);
                rigid = GetComponent<Rigidbody2D>();
                anim = GetComponent<Animator>();
               // wait = new WaitForFixedUpdate();
                
        }

        // Update is called once per frame
        void Update()
        {
                inputVec.x = Input.GetAxis("Horizontal");
                inputVec.y = Input.GetAxis("Vertical");
        }
        private void FixedUpdate()
        {
              //  if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit")) return;
                float scale = Mathf.Abs(transform.position.y) / stendingPos;
                transform.localScale = new Vector3(scale, scale, 1);
                Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
                rigid.MovePosition(rigid.position + inputVec);
        }
        void OnCollisionEnter2D(Collision2D coll)
        {
                if (coll.gameObject.tag == "arrow")
                {
                        transform.position = new Vector3(transform.position.x - 10f, transform.position.y, 0);
                       // StartCoroutine(knockBoack()); ÀÛµ¿¾ÈµÊ 
                      //  anim.SetTrigger("hit");
                }
        }
        /* ÀÛµ¿¾ÈµÊ 
        IEnumerator knockBoack()
        {
                yield return wait;
                Vector3 dirVec = transform.position - transform.position;
                rigid.AddForce(dirVec.normalized*3 , ForceMode2D.Impulse);
        }
        */
}
