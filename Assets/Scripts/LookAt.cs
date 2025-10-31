using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 screenPosition;
    public GameObject crosshair;

	// Update is called once per frame
	void FixedUpdate()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = 6f;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;

        crosshair.transform.position = Input.mousePosition;
    }   

}
