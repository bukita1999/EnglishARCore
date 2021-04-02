using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainTitleBtn : MonoBehaviour
{
    public int sceneNumber;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int num)
    {
        sceneNumber = num;
        Invoke(nameof(WaitForOneNumber), 1f);
    }
    public void ChangeScene(string name)
    {
        sceneName = name;
        Invoke(nameof(WaitForOneName), 1f);
    }
    public void WaitForOneNumber()
    {
        Debug.Log("Title Change");
        SceneManager.LoadScene(sceneNumber);
    }
    public void WaitForOneName()
    {
        Debug.Log("Title Change");
        SceneManager.LoadScene(sceneName);
    }
}
