using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultysend : MonoBehaviour
{
    public int difficult;

    // Start is called before the first frame update
    void Start()
    {
        difficult = 1;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
