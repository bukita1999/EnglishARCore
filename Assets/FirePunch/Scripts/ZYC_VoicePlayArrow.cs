    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.AugmentedImage;

public class ZYC_VoicePlayArrow : MonoBehaviour
{
    float time=5.0f;

    // Start is called before the first frame update
    void Start()
    {
        string name=this.gameObject.transform.parent.gameObject.name;
        ZYC_SoundManager.voice(name);
        Destroy(this.gameObject,ZYC_SoundManager.getLength()+0.1f);
    }

    void OnDestroy()
    {
        transform.parent.GetComponent<ZYC_AugmentedImageVisualizer>().over();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
