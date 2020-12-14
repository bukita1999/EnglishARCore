using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZYC_Text_Manager : MonoBehaviour
{
    public static GameObject text;
    public GameObject temp;
    public static void bornText(string name,Vector3 location,GameObject p){
        GameObject temp=Instantiate(text,location,Quaternion.identity);  //+new Vector3(0,y,0)
        temp.transform.parent=p.transform;
        temp.GetComponent<TextMeshPro>().text=name;
        ZYC_YinxiaoController.zhuangzi();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        text=temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
