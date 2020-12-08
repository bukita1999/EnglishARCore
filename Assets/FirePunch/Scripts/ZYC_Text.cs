using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_Text : MonoBehaviour
{
    public float time;
    public Transform Camera;
    float speed=0.01f;
    void lookAtCamera(){
        Vector3 temp=this.transform.position-Camera.position;
        Vector3 target=this.transform.position+temp;
        transform.LookAt(target);
    }

    void shengqi(){
        transform.position+=Vector3.up*speed*Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera=GameObject.Find("First Person Camera").GetComponent<Transform>();
        Destroy(this.gameObject,time);
    }

    // Update is called once per frame
    void Update()
    {
        shengqi();
        lookAtCamera();
    }
}
