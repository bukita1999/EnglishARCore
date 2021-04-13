using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.AugmentedImage;

public class CC_Status_Change : MonoBehaviour
{
    static Transform M_Camera;
    // Start is called before the first frame update
    void Start()
    {
        M_Camera = GameObject.Find("First Person Camera").transform;
    }

    public static void StartFollow(GameObject item)
    {
        try
        {
            item.GetComponent<HSY_ItemChange>().DrawLine(true);     //箭头显示
            if (item.transform.parent != null)
            {
                item.GetComponent<Rigidbody>().mass = 1000000000;
            }
            else if (item.transform.parent != M_Camera)
            {
                item.GetComponent<Rigidbody>().mass = 1000000000;
            }
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().drag = Mathf.Infinity;
            item.GetComponent<Rigidbody>().angularDrag = Mathf.Infinity;
            item.transform.SetParent(M_Camera);
        }
        catch
        {
            Debug.Log("空了");
            EndFollow(item);
        }
        
    }

    public static void EndFollow(GameObject item)  //被选中物体已经到了盘子上，之后就改变它的parent使其不能再次被选中
    {
        GameObject Dish = GameObject.FindGameObjectWithTag("Dish");
        try
        {
            item.GetComponent<HSY_ItemChange>().DrawLine(false);        //箭头消失
            item.transform.SetParent(Dish.transform);
            item.GetComponent<Rigidbody>().mass = 1;
        }
        catch
        {
            Debug.Log("End空了");
        }
    }

}
