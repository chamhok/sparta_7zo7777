using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resepon : MonoBehaviour
{
        private MeshRenderer meshRenderer;
        public float speed;
        private float offset;
        // Start is called before the first frame update
        void Start()
        {
                meshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
                offset += Time.deltaTime * speed;
                meshRenderer.material.mainTextureOffset = new Vector2(offset, 0);
        }
}
