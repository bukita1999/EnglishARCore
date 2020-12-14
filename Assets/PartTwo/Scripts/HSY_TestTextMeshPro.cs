using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HSY_TestTextMeshPro : MonoBehaviour
{


    public TextMeshPro t;
    // Start is called before the first frame update
    void Start()
    {
        t.GetComponent<TMP_Text>().text = "AAA";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
