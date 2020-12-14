using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZYC_SoundManager : MonoBehaviour
{
    private static AudioSource audioSource = null;
    private static AudioClip audioClip = null;

    public static bool getIsPlaying(){
        return audioSource.isPlaying;
    }

    public static void voice(string objectname){
        audioClip=(AudioClip)Resources.Load("Sounds/Voices/"+objectname);
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public static void setVoice(string objectname){
        audioClip=(AudioClip)Resources.Load("Sounds/Voices/"+objectname);
        audioSource.clip = audioClip;
    }
    public static void stopVoice(){
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    public static void playVoice(){
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public static float getLength(){
        if(audioClip!=null){
            return audioClip.length;
        }
        return 0f;
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
