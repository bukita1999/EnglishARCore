using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZYC_UiController : MonoBehaviour
{
    public Button buttonprefab;
    public Button button;
    public Transform canvas;
    public RectTransform rtr;
    public void DrawButton(GameObject item=null){
        if(button==null){
            button = Instantiate(buttonprefab);
            button.GetComponent<ZYC_Button>().item=item;
            button.transform.SetParent(canvas);
        }
    }

    public void DestroyButton(){
        Destroy(button.gameObject);
        button=null;
    }

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        DrawButton(null);
        #endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
