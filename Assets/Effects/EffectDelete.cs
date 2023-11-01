using UnityEngine;

public class EffectDelete : MonoBehaviour
{
    public float time; // 이 시간이 지나면 게임오브젝트 삭제
    private float t;

    void OnEnable()
    {
        t = 0;
    }
    void Update()
    {
        t += Time.deltaTime;

        if (t >= time)
            Destroy(this.gameObject);
    }
}
