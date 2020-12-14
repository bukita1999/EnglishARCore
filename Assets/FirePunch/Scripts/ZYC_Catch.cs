using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_Catch : MonoBehaviour
{
    public string objectname;
    public GameObject UiController;
    float time=1.0f;
    bool isNext=false;

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<Rigidbody>()!=null){
            return;
        }
        if(this.gameObject.GetComponent<Rigidbody>().useGravity==false){
            return;
        }
        if(collision.gameObject.name=="Dish"){    //XmlAdministrator.addXMLData(objectname)
            XmlAdministrator.addXMLData(objectname);
            ZYC_Text_Manager.bornText(objectname,transform.parent.Find("zhishi").position,transform.parent.gameObject);
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.layer=2;
            if(!isNext){
                isNext=true;
                ZYC_Matter_Controll.next=true;
            }
            //ZYC_SoundManager.voice(objectname);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UiController=GameObject.Find("UiController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
