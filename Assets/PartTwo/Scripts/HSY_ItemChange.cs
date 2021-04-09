using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_ItemChange : MonoBehaviour
{
    public GameObject jiantou;      //选中物体时出现一个箭头

    public void DrawLine(bool b)
    {
        if (b)
        {
            jiantou.SetActive(true);            //使箭头出现
        }
        else
        {
            
            jiantou.SetActive(false);       //使箭头消失

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DrawLine(false);            //开始箭头消失
    }

}
