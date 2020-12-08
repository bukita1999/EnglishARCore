using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneText : MonoBehaviour
{
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Text,this.transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
