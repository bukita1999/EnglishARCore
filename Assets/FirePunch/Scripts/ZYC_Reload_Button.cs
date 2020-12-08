using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ZYC_Reload_Button : MonoBehaviour,IPointerClickHandler
{
    public GameObject item;
    public int length;
    public int scale=10;
    public Transform Camera;

    void ButtonStart(){
        Camera=GameObject.Find("First Person Camera").transform;
        RectTransform rtr= this.gameObject.GetComponent<RectTransform>();
        //设置父级基准位置
        rtr.anchorMin = new Vector2(0.1f,0.9f);
        rtr.anchorMax = new Vector2(0.1f,0.9f);
        //定义控件自身定位点位置
        rtr.pivot = new Vector2(0.5f, 0.5f);
        //定义控件定位点相对基准位置的偏移
        rtr.anchoredPosition = new Vector2(0, 0);
        length=Mathf.Max(Screen.width,Screen.height);
        rtr.sizeDelta = new Vector2(length/scale, length/scale);
    }

    public void OnPointerClick(PointerEventData eventData){
        SceneManager.LoadScene("FirstPart");
    }

    void ButtonUpdate(){
        if(length!=Mathf.Max(Screen.width,Screen.height)){
            length=Mathf.Max(Screen.width,Screen.height);
            RectTransform rtr= this.gameObject.GetComponent<RectTransform>();
            rtr.sizeDelta = new Vector2(length/scale, length/scale);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ButtonStart();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonUpdate();
    }
}
