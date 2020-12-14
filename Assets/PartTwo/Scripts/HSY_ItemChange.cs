using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_ItemChange : MonoBehaviour
{
    public Material diffuse;
    public Material drawline;
    public Renderer rend;
    public GameObject jiantou;

    public void DrawLine(bool b)
    {
        if (b)
        {
            if (drawline != null)
            {
                rend.sharedMaterial = drawline;
            }
            else
            {
                jiantou.SetActive(true);
            }
        }
        else
        {
            if (diffuse != null)
            {
                rend.sharedMaterial = diffuse;
            }
            else
            {
                jiantou.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        DrawLine(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
