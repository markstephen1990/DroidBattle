using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public InputField playerNickname;
    private string setName = "";
    public GameObject connecting;

    // Start is called before the first frame update
    void Start()
    {
        connecting.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateText()
    {
        setName = playerNickname.text;
        PhotonNetwork.LocalPlayer.NickName = setName;
    }

    public void EnterButton()
    {
        if (setName != "")
        {
			PhotonNetwork.AutomaticallySyncScene = true;
			PhotonNetwork.ConnectUsingSettings();
            connecting.SetActive(true);
		}
	}

    public void ExitButton()
    {
        Application.Quit();
    }

	public override void OnConnectedToMaster()
	{
        SceneManager.LoadScene("Lobby");
	}

	
}
