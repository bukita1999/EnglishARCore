using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainTitleBtn : MonoBehaviour
{
    private int sceneNumber;
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
        Invoke(nameof(WaitForOne), 1f);
    }
    public void WaitForOne()
    {
        Debug.Log("Title Change");
        SceneManager.LoadScene(sceneNumber);
    }
    
}
