using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_Dish_Forward : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3  tar = transform.position+Vector3.up;
        transform.LookAt(tar);
    }
}
