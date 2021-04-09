using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CC_WaitinRoomID : MonoBehaviour
{
    public GameObject HostID;
    // Start is called before the first frame update
    void Start()
    {
        if(OnlineManager.GetInstance() != null)
        {
            HostID.GetComponent<Text>().text = OnlineManager.GetInstance().user_number.ToString();
        }
    }
 
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
