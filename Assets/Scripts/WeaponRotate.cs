using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    public float speed = 20;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PhotonView>().Owner.IsMasterClient) //new
        {
            GetComponent<PhotonView>().RPC("Rotator", RpcTarget.All);
        }
        //transform.Rotate(0,speed * Time.deltaTime, 0);
    }

    [PunRPC]
    void Rotator()
    {
		transform.Rotate(0,speed* Time.deltaTime, 0);
    }
}
