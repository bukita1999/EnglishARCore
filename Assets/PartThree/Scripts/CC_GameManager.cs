using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CC_GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public bool Player_Status;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Photon Callbacks
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("WaitinRoom");
    }
    #endregion
    #region Public Methods


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    #endregion

    #region Private Methods


    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("BattleRoom");
    }


    #endregion
}
