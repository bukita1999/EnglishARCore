using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_Text01 : MonoBehaviour
{

    void test(){
        XmlAdministrator.addXMLData("sample");
        XmlAdministrator.addXMLData("apple");
        XmlAdministrator.addXMLData("banana");
        XmlAdministrator.addXMLData("apple");
        XmlAdministrator.addXMLData("sample");
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("test",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
