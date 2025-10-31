using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviourPunCallbacks
{
    TypedLobby killCount = new TypedLobby("killCount", LobbyType.Default);
	TypedLobby teamBattle = new TypedLobby("teamBattle", LobbyType.Default);
	TypedLobby noRespawn = new TypedLobby("noRespawn", LobbyType.Default);

	public GameObject roomNumber;

	private string levelName = "";

	private void Start()
	{
		roomNumber.SetActive(false);
	}
	public void BackToMenu()
    {
		PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }

    public void JoinGameKillCount()
    {
		levelName = "KillCount";
		PhotonNetwork.JoinLobby(killCount);
    }

	public void JoinGameTeamBattle()
	{
		levelName = "TeamBattle";
		PhotonNetwork.JoinLobby(teamBattle);
	}

	public void JoinGameNoRespawn()
	{
		levelName = "NoRespawn";
		PhotonNetwork.JoinLobby(noRespawn);
	}

	public override void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.MaxPlayers = 6;
		PhotonNetwork.CreateRoom("Arena" + Random.Range(1, 1000), roomOptions);
	}

	public override void OnJoinedRoom()
	{
		roomNumber.SetActive(true);
		PhotonNetwork.LoadLevel(levelName);
	}

}
