using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZYC_RayController : MonoBehaviour
{
    public GameObject item=null;
    public ZYC_UiController uiController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }

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

            if(item==null){
                item=hitInfo.transform.gameObject;
                item.GetComponent<ZYC_ItemChange>().DrawLine(true);
                DrawUi(item);
            }else if(item!=hitInfo.transform.gameObject){
                item.GetComponent<ZYC_ItemChange>().DrawLine(false);
                item=hitInfo.transform.gameObject;
                item.GetComponent<ZYC_ItemChange>().DrawLine(true);
                DestroyUi();
                DrawUi(item);
            }
        }else{
            if(item!=null){
                item.GetComponent<ZYC_ItemChange>().DrawLine(false);
                item=null;
                DestroyUi();
            }
        }
    }

    void DrawUi(GameObject item){   
        uiController.DrawButton(item);
    }

    void DestroyUi(){
        uiController.DestroyButton();
    }
}
