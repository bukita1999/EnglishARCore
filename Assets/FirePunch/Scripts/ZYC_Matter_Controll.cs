using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_Matter_Controll : MonoBehaviour
{
    float time=9.0f;
    public GameObject[] objects;
    public float[] times;
    public string[] voicenames;
    public int current;
    public static bool next=false;
    public GameObject all;

    public bool nextMatter(){
        current++;
        if(current>=objects.Length){
            return  false;
        }
        if(current==0){
            Invoke("nextMatter_1",0f);
        }else{
            Invoke("nextMatter_1",0.025f);
        }
        return  true;
    }

    void nextMatter_1(){
        Invoke("GenerateObject",times[current]);
        ZYC_SoundManager.setVoice(voicenames[current]);
        ZYC_SoundManager.playVoice();
    }

    public void GenerateObject(){
        objects[current].SetActive(true);
        ZYC_SoundManager.stopVoice();
    }

    // Start is called before the first frame update
    void Start()
    {
        ZYC_YinxiaoController.kaimu();
        current=-1;
        Invoke("nextMatter",0.015f);
    }

    // Update is called once per frame
    void Update()
    {
        if(next){
            if(!nextMatter()){
                Destroy(all,time);
            }
            next=false;
        }
    }
}
