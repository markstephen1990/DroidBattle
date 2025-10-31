using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnTimer : MonoBehaviour
{
    public Text spawnTime;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(SpawnStarting());
    }

    IEnumerator SpawnStarting()
    {
        spawnTime.text = "3";
        yield return new WaitForSeconds(1);
		spawnTime.text = "2";
		yield return new WaitForSeconds(1);
		spawnTime.text = "1";
		yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
	}
}
