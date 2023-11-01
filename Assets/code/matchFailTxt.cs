using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class matchFailTxt : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myTxt;
    void Start()
    {
        Invoke("destroyMySelf", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroyMySelf()
    {
        Destroy(gameObject);
    }
    public void setMyTxt(float score)
    {
        if(score < 1)
        {
			myTxt.text = "-" + score.ToString("N1");
		}
        else
        {
            myTxt.text = "-" + score.ToString("N0");
        }
        
    }
}
