using UnityEngine;

public class EffectDelete : MonoBehaviour
{
    public float time; // �� �ð��� ������ ���ӿ�����Ʈ ����
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
