using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CC_GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public bool Player_Status;
    public static CC_GameManager instance;
    public float myScore;

    //public PlayerPrefs host;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Debug.Log(gameObject.GetPhotonView().ViewID);
        
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

    public void Finalcount(float score)
    {
        PhotonView photonView = new PhotonView();
        if(!PhotonNetwork.IsMasterClient)
            photonView.RPC(nameof(comparsion),RpcTarget.Others,score);
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

    [PunRPC]
    void comparsion(float score)
    {
        PhotonView photonView = new PhotonView();
        myScore = CC_PositiveAnswerRate._instance.PositiveNum;
        int final;
        if(myScore>score)
        {
            Debug.Log("hostwin");
            final = 1;
        }
        else if(myScore == score)
        {
            Debug.Log("fair");
            final = 0;
            
        }
        else
        {
            Debug.Log("HostLose");
            final = -1;
        }
        Debug.Log("成功加入Dictionary");
        photonView.RPC(nameof(result_back), RpcTarget.Others, final);
    }

    [PunRPC]
    void result_back(int final)
    {
        string content = "平局";
        if(final==1)
        {
            content = "你输了";
            Debug.Log(content);
        }
        else if(final==0)
        {
            content = "平局";
            Debug.Log(content);
        }
        else if(final==-1)
        {
            content = "你赢了";
            Debug.Log(content);
        }
        CC_PositiveAnswerRate._instance.Change_Win_Lose_Status(content);
    }
    

}
    #endregion

