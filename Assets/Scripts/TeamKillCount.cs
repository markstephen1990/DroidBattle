using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamKillCount : MonoBehaviour
{
	public List<Kills> highestKills = new List<Kills>();
	public Text[] killAmts;
	private GameObject killCountPanel;
	private GameObject namesObject;
	private bool killCountOn = false;
	public bool countDown = true;
	public GameObject winnerPanel;
	public Text winnerText;
	private int RedTeamKills;
	private int GreenTeamKills;

	// Start is called before the first frame update
	void Start()
    {
		killCountPanel = GameObject.Find("KillCountPanel");
		namesObject = GameObject.Find("namesBG");
		killCountPanel.SetActive(false);
		winnerPanel.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.K) && countDown == true)
		{
			if (killCountOn == false)
			{
				killCountPanel.SetActive(true);
				killCountOn = true;
				highestKills.Clear();
				for (int i = 0; i < 6; i++)
				{
					highestKills.Add(new Kills(namesObject.GetComponent<NickNamesScript>().names[i].text, namesObject.GetComponent<NickNamesScript>().kills[i]));

				}
				RedTeamKills = highestKills[0].playerKills + highestKills[1].playerKills + highestKills[2].playerKills;
				GreenTeamKills = highestKills[3].playerKills + highestKills[4].playerKills + highestKills[5].playerKills;
				killAmts[0].text = RedTeamKills.ToString();
				killAmts[1].text = GreenTeamKills.ToString();

			}
			else if (killCountOn == true)
			{
				killCountPanel.SetActive(false);
				killCountOn = false;
			}
		}
	}

	public void TimeOver()
	{
		killCountPanel.SetActive(true);
		winnerPanel.SetActive(true);
		killCountOn = true;
		highestKills.Clear();
		for (int i = 0; i < 6; i++)
		{
			highestKills.Add(new Kills(namesObject.GetComponent<NickNamesScript>().names[i].text, namesObject.GetComponent<NickNamesScript>().kills[i]));

		}
		RedTeamKills = highestKills[0].playerKills + highestKills[1].playerKills + highestKills[2].playerKills;
		GreenTeamKills = highestKills[3].playerKills + highestKills[4].playerKills + highestKills[5].playerKills;
		killAmts[0].text = RedTeamKills.ToString();
		killAmts[1].text = GreenTeamKills.ToString();
		if (RedTeamKills > GreenTeamKills)
		{
			winnerText.text = "RED TEAM WINS";
		}
		if (RedTeamKills < GreenTeamKills)
		{
			winnerText.text = "GREEN TEAM WINS";
		}
	}
}
