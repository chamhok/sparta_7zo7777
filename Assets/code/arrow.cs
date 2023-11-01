using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
        float arrowPos;
        float arrowScale_x;
        float arrowScale_y;
        // Start is called before the first frame update
        void Start()
        {
                arrowPos = Mathf.Abs(transform.position.y);
                arrowScale_x = transform.localScale.x;
                arrowScale_y = transform.localScale.y;
                float x = 70f;
                float y = Random.Range(60f, 110f);
                transform.position = new Vector3(x,-y, 0);
        }

        private void FixedUpdate()
        {
                //ȭ���� x���� ���� ������
                if (transform.position.x < -70)
                {
                        Destroy(gameObject);
                }
                float scale = Mathf.Abs(transform.position.y) / arrowPos;           // ���� �����ǰ� ���� ������ �Ǵ� �������� ������.
                transform.localScale = new Vector3(scale * arrowScale_x, scale * arrowScale_y, 1);   // �������� �̿��� ũ�� ���� (���� ���� ���� �����ϰ� ���Ѵ�.)
                transform.position -= new Vector3(1f, 0, 0);
        }
        // Update is called once per frame
        void Update()
        {
              
        }
        void OnCollisionEnter2D(Collision2D coll)
        {
                if (coll.gameObject.tag == "minirun")
                {
                        Destroy(gameObject);
                }
        }
}
