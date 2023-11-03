using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{

        float DrinkPos;
        float DrinkScale_x;
        float DrinkScale_y;
        float level;
        int levelCount = 0;
        void Start()
        {
                DrinkPos = Mathf.Abs(transform.position.y);
                DrinkScale_x = transform.localScale.x;
                DrinkScale_y = transform.localScale.y;
                float x = 80f;
                float y = Random.Range(60f, 110f);
                transform.position = new Vector3(x, -y, 0);
                float scale = Mathf.Abs(transform.position.y) / DrinkPos;           // ���� �����ǰ� ���� ������ �Ǵ� �������� ������.
                transform.localScale = new Vector3(scale * DrinkScale_x, scale * DrinkScale_y, 1);   // �������� �̿��� ũ�� ���� (���� ���� ���� �����ϰ� ���Ѵ�.)
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

        private void FixedUpdate()
        {
                //�帵ũ�� x���� ���� ������
                if (transform.position.x < -70)
                {
                        Destroy(gameObject);
                }
                transform.position -= new Vector3(1f, 0, 0);
                LevelUp();

        }

        void OnCollisionEnter2D(Collision2D coll)
        {
                if (coll.gameObject.tag == "minirun")
                {
                        MiniGameManager.I.health += 10;
                        Destroy(gameObject);
                }
        }
}
