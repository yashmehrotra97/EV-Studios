using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSetUpController : MonoBehaviour
{
    public Transform[] pos;
    public GameObject ball;
    int numberOfPlayers = 0;
    public Button loadingButton, backButton;

    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Vector3 emptyPos;

        CheckPlayers();

        Debug.Log("Creating Player");

        if (numberOfPlayers == 1)
        {
            emptyPos = pos[0].position;
        }
        else
        {
            emptyPos = pos[1].position;
        }

        PhotonNetwork.Instantiate(ball.name, emptyPos, Quaternion.identity);
    }

    void CheckPlayers()
    {
        numberOfPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public void BackButton()
    {
        backButton.gameObject.SetActive(false);
        loadingButton.gameObject.SetActive(true);
        PhotonNetwork.Disconnect();
        Invoke("loadlevel", 2f);
    }

    void loadlevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}