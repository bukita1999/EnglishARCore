using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GoogleARCore.Examples.AugmentedImage;

//using Input = GoogleARCore.InstantPreviewInput;


public class CC_RayController : MonoBehaviour
{
    public GameObject item = null;
    public static CC_RayController instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
#if UNITY_EDITOR
#else
                    if(Input.touchCount==0){
                        return;
                    }
#endif

        Ray ray;
        if (Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;   //存储射线碰撞到的第一个对象信息


            if (Physics.Raycast(ray, out hitInfo)) //点击的是物体
            {
                if (item == null)  //之前未选中物体
                { //第一次选中
                    item = hitInfo.transform.gameObject;
                    CC_Status_Change.StartFollow(item);
                }
                else if (item != hitInfo.transform.gameObject)   //之前选中了物体，但不是当前触碰的物体
                {   //切换物体
                    CC_Status_Change.EndFollow(item);
                    item = hitInfo.transform.gameObject;
                    CC_Status_Change.StartFollow(item);
                }
            }
            else  //点击的是空白处
            {
                if (item != null)
                { //选中空白
                    CC_Status_Change.EndFollow(item);
                    item = null;
                }
            }
        }

    }

}
