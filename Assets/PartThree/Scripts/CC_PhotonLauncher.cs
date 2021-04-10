using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CC_PhotonLauncher : MonoBehaviourPunCallbacks
{
    public GameObject HostID;
    public GameObject inputfield;
    public GameObject ConnectingText;
    public GameObject Host_btn;
    public GameObject Guest_btn;
    #region Private Serializable Fields

    

    #endregion


    #region Private Fields

    private bool isConnecting;

    /// <summary>
    /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
    /// </summary>
    string gameVersion = "1";


    #endregion


    #region MonoBehaviour CallBacks


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
    /// </summary>
    void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    /// <summary>
    /// MonoBehaviour method called on GameObject by Unity during initialization phase.
    /// </summary>
    void Start()
    {
        Host_btn.SetActive(false);
        Guest_btn.SetActive(false);
        if (PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion.ToString();
            ConnectingText.SetActive(true);
            
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To the Master");
        ConnectingText.SetActive(false);
        Host_btn.SetActive(true);
        Guest_btn.SetActive(true);
    }
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("BattleRoom");
    }

    #endregion


    #region Public Methods


    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect(bool Host)
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        
        
        
        if (Host)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible = true;
            roomOptions.MaxPlayers = 2;
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.CreateRoom(HostID.GetComponent<Text>().text, roomOptions);
            
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.JoinRoom(inputfield.GetComponent<InputField>().text);
        }
    }
    #endregion

    
}
