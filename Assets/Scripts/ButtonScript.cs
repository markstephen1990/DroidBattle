using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Runtime.CompilerServices;

public class ButtonScript : MonoBehaviour
{
    private GameObject[] players;
    private int myID;
    private GameObject panel;
    private GameObject namesObject;


	private void Start()
	{
        Cursor.visible = true;
        panel = GameObject.Find("ChoosePanel");
        namesObject = GameObject.Find("namesBG");
	}

	public void SelectButton(int buttonNumber)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<PhotonView>().IsMine == true)
            {
                myID = players[i].GetComponent<PhotonView>().ViewID; 
                break;
            }
        }
        GetComponent<PhotonView>().RPC("SelectedColor", RpcTarget.AllBuffered, buttonNumber, myID);
        Cursor.visible = false;
        panel.SetActive(false);
    }

    [PunRPC]
    void SelectedColor(int buttonNumber, int myID)
    {
		players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<DisplayColor>().viewID[buttonNumber] = myID;
            players[i].GetComponent<DisplayColor>().ChooseColor();
        }
        namesObject.GetComponent<Timer>().BeginTimer();
        this.transform.gameObject.SetActive(false);
	}
}
