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
                float scale = Mathf.Abs(transform.position.y) / DrinkPos;           // 현재 포지션과 원래 기준이 되는 포지션을 나눈다.
                transform.localScale = new Vector3(scale * DrinkScale_x, scale * DrinkScale_y, 1);   // 스케일을 이용해 크기 조절 (나눈 값을 원래 스케일과 곱한다.)
        }
        //시간에 따라 화살속도 레벨을 올린다.
        void LevelUp()
        {
                if (levelCount > MiniGameManager.I.nextTime.Length - 1) levelCount = MiniGameManager.I.nextTime.Length - 1; // 졸라 초고수가 나올수도 있으니 이렇게 버그안나게 수정

                //currentTime이  MiniGameManager.I.nextTime[levelCount]보다 높으면 레벨이 상승한다. 그다음 레벨카운트가 상승 레벨카운트가 상승하면 목표시간이 바뀐다.
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
                //드링크의 x값에 따라 삭제함
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
