using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_LocRot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Log："+"loc："+this.transform.position+"rot："+this.transform.rotation);
    }
}
