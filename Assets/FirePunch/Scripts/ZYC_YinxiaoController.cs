using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_YinxiaoController : MonoBehaviour
{
    private static AudioSource audioSource;
    public static AudioClip audioClip;

    public static bool getIsPlaying(){
        return audioSource.isPlaying;
    }

    public static void stopVoice(){
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public static void zhuangzi(){
        audioClip=(AudioClip)Resources.Load("Sounds/Voices/"+"Part1_Plate");
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public static void kaimu(){
        audioClip=(AudioClip)Resources.Load("Sounds/Voices/"+"Part1_Start");
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
