using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_VoicePlayArrow : MonoBehaviour
{
    public float time=5.0f;

    // Start is called before the first frame update
    void Start()
    {
        string name=this.gameObject.transform.parent.gameObject.name;
        ZYC_SoundManager.voice(name);
        Destroy(this.gameObject,time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
