using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
        float arrowPos;
        // Start is called before the first frame update
        void Start()
        {
                arrowPos = Mathf.Abs(transform.position.y);
                float x = 70f;
                float y = Random.Range(60f, 110f);
                transform.position = new Vector3(x,-y, 0);
        }

        // Update is called once per frame
        void Update()
        {
                if (transform.position.x < -70)
                {
                        Destroy(gameObject);
                }
                float scale = Mathf.Abs(transform.position.y) / arrowPos;
                transform.localScale = new Vector3(scale*20, scale*20, 1);
                transform.position -= new Vector3(0.1f, 0, 0);
        }
        void OnCollisionEnter2D(Collision2D coll)
        {
                if (coll.gameObject.tag == "minirun")
                {
                        Destroy(gameObject);
                }
        }
}
