using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_Catch : MonoBehaviour
{
    public GameObject UiController;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            return;
        }
        if (this.gameObject.GetComponent<Rigidbody>().useGravity == false)
        {
            return;
        }
    }

    void Start()
    {
        UiController = GameObject.Find("UiController");
    }

}
