using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingTextFollow : MonoBehaviour
{
        RectTransform rect;
        // Start is called before the first frame update
        private void Awake()
        {
                rect = GetComponent<RectTransform>();
        }

        private void FixedUpdate()
        {
                rect.position = Camera.main.WorldToScreenPoint(new Vector3(MiniGameManager.I.run.transform.position.x+30,(MiniGameManager.I.run.transform.position.y)+17f, MiniGameManager.I.run.transform.position.z));
        }
}
