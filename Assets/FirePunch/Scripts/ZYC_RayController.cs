using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GoogleARCore.Examples.AugmentedImage;

public class ZYC_RayController : MonoBehaviour
{
    public GameObject item=null;

    void DrawLine(){
        #if UNITY_EDITOR
            Debug.Log(EventSystem.current.IsPointerOverGameObject());
        #else
            if(Input.touchCount==0){
                return;
            }
        #endif
        
        if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
                return;
            }

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray,out hitInfo))
        {
            if(item==null){ //第一次选中
                item=hitInfo.transform.gameObject;
                ZYC_Status_Change.StartFollow(item);
            }else if(item!=hitInfo.transform.gameObject){   //切换物体
                ZYC_Status_Change.EndFollow(item);
                item=hitInfo.transform.gameObject;
                ZYC_Status_Change.StartFollow(item);
            }
        }else{
            if(item!=null){ //选中空白
                ZYC_Status_Change.EndFollow(item);
                item=null;
            }
        }
    }
}
