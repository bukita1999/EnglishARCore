using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_TestTrigger : MonoBehaviour
{
    public Transform target;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent == null && other.gameObject.GetComponent<Rigidbody>().useGravity == false)
        {
            //other.gameObject.transform.parent = target;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<Rigidbody>().drag = 0;
            other.gameObject.GetComponent<Rigidbody>().angularDrag = 0.05f;

            if (other.gameObject.name == "egg")
            {
                Debug.Log("AAA");
                //other.gameObject.SetActive(false);
            }
        }
    }

   
    /*private void OnTriggerEnter(Collider other)
    {
        
    }*/
}
