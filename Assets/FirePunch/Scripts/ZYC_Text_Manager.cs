using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_Text_Manager : MonoBehaviour
{
    public static GameObject text;
    public GameObject temp;

    public static void bornText(string name,Vector3 location){
        GameObject temp=Instantiate(text,location,Quaternion.identity);
        temp.GetComponent<TMPro.TextMeshPro>().text=name;
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
