using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

public class CC_notification_textchanged : MonoBehaviour
{
    public Text notification_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TextChanged(string changeText)
    {
        notification_text.text = changeText;
        this.GetComponent<LeanPulse>().Pulse();
    }
}
