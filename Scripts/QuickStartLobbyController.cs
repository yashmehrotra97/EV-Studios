using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject quickStartButton = null;
    [SerializeField]
    private GameObject loadingButton = null;
    [SerializeField]
    private int Roomsize = 0;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        loadingButton.SetActive(false);
        quickStartButton.SetActive(true);
    }

    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        loadingButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("QuickStart");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Fail to join the room");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("creating room now");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true ,MaxPlayers = (byte) Roomsize};
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom();
    }

    public void QuickCancel()
    {
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
    public void QuickExit()
    {
        Application.Quit();
    }

}
