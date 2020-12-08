using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_DishCollider : MonoBehaviour
{
    public Transform target;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.transform.parent==null&&other.gameObject.GetComponent<Rigidbody>().useGravity==false){
            other.gameObject.transform.parent=target;
            other.gameObject.GetComponent<Rigidbody>().useGravity=true;
            other.gameObject.GetComponent<Rigidbody>().drag=0;
            other.gameObject.GetComponent<Rigidbody>().angularDrag=0.05f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
