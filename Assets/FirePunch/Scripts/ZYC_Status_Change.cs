using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.AugmentedImage;

public class ZYC_Status_Change : MonoBehaviour
{
    static Transform M_Camera;
    // Start is called before the first frame update
    void Start()
    {
        M_Camera=GameObject.Find("First Person Camera").transform;
    }

    public static void StartFollow(GameObject item){
        item.GetComponent<ZYC_ItemChange>().DrawLine(true);
        if(item.transform.parent!=null&&item.transform.parent.gameObject.GetComponent<ZYC_AugmentedImageVisualizer>()!=null){
            item.transform.parent.gameObject.GetComponent<ZYC_AugmentedImageVisualizer>().isOverImage=false;
            //item.GetComponent<Rigidbody>().mass=item.GetComponent<Rigidbody>().mass*=10;
            item.GetComponent<Rigidbody>().mass=1000000000;
        }else if(item.transform.parent!=M_Camera){
            //item.GetComponent<Rigidbody>().mass=item.GetComponent<Rigidbody>().mass*=10;
            item.GetComponent<Rigidbody>().mass=1000000000;
        }
        item.GetComponent<Rigidbody>().useGravity=false;
        item.GetComponent<Rigidbody>().drag=Mathf.Infinity;
        item.GetComponent<Rigidbody>().angularDrag=Mathf.Infinity;
        item.transform.SetParent(M_Camera);
    }

    public static void EndFollow(GameObject item){
        GameObject Dish=GameObject.FindGameObjectWithTag("Dish");
        item.GetComponent<ZYC_ItemChange>().DrawLine(false);
        item.transform.SetParent(Dish.transform);
        item.GetComponent<Rigidbody>().mass=1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
