using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NickNamesScript : MonoBehaviourPunCallbacks
{
	public Text[] names;
	public Image[] healthbars;
	private GameObject waitObject;
	public GameObject displayPanel;
	public Text messageText;
	public int[] kills;
	public bool teamMode = false;
	public bool noRespawn = false;
	public GameObject eliminationPanel;

	private void Start()
	{
		if (noRespawn == true)
		{
			eliminationPanel.SetActive(false);
		}
		displayPanel.SetActive(false);
		for (int i = 0; i < names.Length; i++)
		{
			names[i].gameObject.SetActive(false);
			healthbars[i].gameObject.SetActive(false);
		}
		waitObject = GameObject.Find("Waiting BG");
	}

	public void Leaving()
	{
		StartCoroutine("BackToLobby");
	}

	IEnumerator BackToLobby()
	{
		yield return new WaitForSeconds(0.5f);
		PhotonNetwork.LoadLevel("Lobby");
	}

	//This is for the Waiting screen

	public void ReturnToLobby()
	{
		waitObject.SetActive(false);
		RoomExit();
	}

	void RoomExit()
	{
		StartCoroutine(ToLobby());
	}

	public void RunMessage(string win, string lose)
	{
		this.GetComponent<PhotonView>().RPC("DisplayMessage", RpcTarget.All, win, lose);
		UpdateKills(win);
	}

	void UpdateKills(string win)
	{
		for (int i = 0; i < names.Length; i++)
		{
			if (win == names[i].text)
			{
				kills[i]++;
			}
		}
	}

	[PunRPC]
	void DisplayMessage(string win, string lose)
	{
		displayPanel.SetActive(true);
		messageText.text = win + " killed " + lose;
		StartCoroutine(SwitchOffMessage());
	}

	IEnumerator SwitchOffMessage()
	{
		yield return new WaitForSeconds(3);
		this.GetComponent<PhotonView>().RPC("MessageOff", RpcTarget.All);
	}

	[PunRPC]
	void MessageOff()
	{
		displayPanel.SetActive(false);
	}

	IEnumerator ToLobby()
	{
		yield return new WaitForSeconds(0.4f);
		Cursor.visible = true;
		PhotonNetwork.LeaveRoom();
	}

	public override void OnLeftRoom()
	{
		PhotonNetwork.LoadLevel("Lobby");
	}
}
