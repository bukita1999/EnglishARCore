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
        
        if (!PhotonNetwork.IsMasterClient)
        {
            CC_PositiveAnswerRate._instance.Change_Win_Lose_Status("SendingResults");
            gameObject.GetPhotonView().RPC(nameof(comparsion), RpcTarget.Others, score.ToString());
        }
        else
        {
            CC_PositiveAnswerRate._instance.Change_Win_Lose_Status("I am the Master");
        }
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
    void comparsion(string str_score)
    {
        float score = float.Parse(str_score);
        CC_PositiveAnswerRate._instance.Change_Win_Lose_Status("received content:"+str_score);
        PhotonView photonView = gameObject.GetPhotonView();
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
        string content = "平局";
        if (final == 1)
        {
            content = "Win";
            Debug.Log(content);
        }
        else if (final == 0)
        {
            content = "Fair";
            Debug.Log(content);
        }
        else if (final == -1)
        {
            content = "Lose";
            Debug.Log(content);
        }
        CC_PositiveAnswerRate._instance.Change_Win_Lose_Status(content);

        photonView.RPC(nameof(result_back), RpcTarget.Others, final.ToString());
    }

    [PunRPC]
    void result_back(string str_final)
    {
        CC_PositiveAnswerRate._instance.Change_Win_Lose_Status("Receive Respond");
        string content = "BackReceived";
        int final = int.Parse(str_final);
        if(final==1)
        {
            content = "Lose";
            Debug.Log(content);
        }
        else if(final==0)
        {
            content = "Fair";
            Debug.Log(content);
        }
        else if(final==-1)
        {
            content = "Win";
            Debug.Log(content);
        }
        else
        {
            content = "Something wrong";
        }
        CC_PositiveAnswerRate._instance.Change_Win_Lose_Status(content);
    }
    

}
    #endregion

