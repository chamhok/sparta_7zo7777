using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
        float arrowPos;
        float arrowScale_x;
        float arrowScale_y;
        float level;
        int levelCount = 0;
        GameObject hurryup;

        void Start()
        {
                level = MiniGameManager.I.level;
                arrowPos = Mathf.Abs(transform.position.y);
                arrowScale_x = transform.localScale.x;
                arrowScale_y = transform.localScale.y;
                float x = 80f;
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
                LevelUp();
        }
        //�ð��� ���� ȭ��ӵ� ������ �ø���.
        void LevelUp()
        {
                if (levelCount > MiniGameManager.I.nextTime.Length - 1) levelCount = MiniGameManager.I.nextTime.Length - 1; // ���� �ʰ���� ���ü��� ������ �̷��� ���׾ȳ��� ����

                //currentTime��  MiniGameManager.I.nextTime[levelCount]���� ������ ������ ����Ѵ�. �״��� ����ī��Ʈ�� ��� ����ī��Ʈ�� ����ϸ� ��ǥ�ð��� �ٲ��.
                if (MiniGameManager.I.currentTime > MiniGameManager.I.nextTime[levelCount])
                {
                        level += (float)levelCount;
                        transform.position -= new Vector3(level, 0, 0);
                        levelCount++;
                        
                }
                else transform.position -= new Vector3(level, 0, 0);



        }
        void OnCollisionEnter2D(Collision2D coll)
        {
                if (coll.gameObject.tag == "minirun")
                {
                        Destroy(gameObject);
                }
        }
}
