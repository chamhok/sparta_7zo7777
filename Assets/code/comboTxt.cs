using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comboTxt : MonoBehaviour
{

    public Text myTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //1~8 값 받고 색깔 변경
    public void setColor(int count)
    {
        switch(count)
        {
            case 1:
                myTxt.color = Color.red;
                setTxt(count);
                break;
			case 2:
				myTxt.color = new Color(1f, 50/255f, 0f); //주황색
				setTxt(count);
				break;
			case 3:
				myTxt.color = Color.yellow;
				setTxt(count);
				break;
			case 4:
				myTxt.color = Color.green;
				setTxt(count);
				break;
			case 5:
				myTxt.color = Color.blue;
				setTxt(count);
				break;
			case 6:
				myTxt.color = new Color(0, 50/255f, 1f); //남색
				setTxt(count);
				break;
			case 7:
				myTxt.color = new Color(100/255f, 0, 1f); // 보라색
				setTxt(count);
				break;
			default:
				myTxt.color = Color.black;
				setTxt(count);
				break;

		}
    }

    void setTxt(int count)
    {
        myTxt.text = count.ToString() + "Combo!";
    }
}
