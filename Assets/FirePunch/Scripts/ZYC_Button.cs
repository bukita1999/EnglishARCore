using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GoogleARCore;
using GoogleARCore.Examples.AugmentedImage;

public class ZYC_Button : MonoBehaviour, IPointerClickHandler,IPointerDownHandler
{
    public GameObject item;
    public int length;
    public int scale=10;
    public Transform Camera;

    public void OnPointerClick(PointerEventData eventData){
        item.transform.SetParent(null);
        //item.GetComponent<Rigidbody>().mass=item.GetComponent<Rigidbody>().mass/=10;
        item.GetComponent<Rigidbody>().mass=1;
		//Destroy(item);
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera=GameObject.Find("First Person Camera").transform;
        RectTransform rtr= this.gameObject.GetComponent<RectTransform>();
        //设置父级基准位置
        rtr.anchorMin = new Vector2(0.8f,0.2f);
        rtr.anchorMax = new Vector2(0.8f,0.2f);
        //定义控件自身定位点位置
        rtr.pivot = new Vector2(0.5f, 0.5f);
        //定义控件定位点相对基准位置的偏移
        rtr.anchoredPosition = new Vector2(0, 0);
        length=Mathf.Max(Screen.width,Screen.height);
        rtr.sizeDelta = new Vector2(length/scale, length/scale);
    }

    // Update is called once per frame
    void Update()
    {
        if(length!=Mathf.Max(Screen.width,Screen.height)){
            length=Mathf.Max(Screen.width,Screen.height);
            RectTransform rtr= this.gameObject.GetComponent<RectTransform>();
            rtr.sizeDelta = new Vector2(length/scale, length/scale);
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        if(item.transform.parent!=null&&item.transform.parent.gameObject.GetComponent<ZYC_AugmentedImageVisualizer>()!=null){
            item.transform.parent.gameObject.GetComponent<ZYC_AugmentedImageVisualizer>().isOverImage=false;
            //item.GetComponent<Rigidbody>().mass=item.GetComponent<Rigidbody>().mass*=10;
            item.GetComponent<Rigidbody>().mass=1000000000;
        }else if(item.transform.parent!=Camera){
            //item.GetComponent<Rigidbody>().mass=item.GetComponent<Rigidbody>().mass*=10;
            item.GetComponent<Rigidbody>().mass=1000000000;
        }
        item.GetComponent<Rigidbody>().useGravity=false;
        item.GetComponent<Rigidbody>().drag=Mathf.Infinity;
        item.GetComponent<Rigidbody>().angularDrag=Mathf.Infinity;
		item.transform.SetParent(Camera);
    }
}
