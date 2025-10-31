using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnCharacters : MonoBehaviour
{
    public GameObject character;
    public Transform[] spawnPoints;
    public GameObject[] weapons;
    public Transform[] weaponSpawnPoints;
    public float weaponRespawnTime = 10;

    // Start is called before the first frame update
    void Start()
    {
       if (PhotonNetwork.IsConnected)
        {
            
            PhotonNetwork.Instantiate(character.name, spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount - 1].position, spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount - 1].rotation);
		}
    }
	
	// Update is called once per frame
	void Update()
    {

    }

    public void SpawnWeaponsStart()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            PhotonNetwork.Instantiate(weapons[i].name, weaponSpawnPoints[i].position, weaponSpawnPoints[i].rotation);
        }
    }    
    
}
