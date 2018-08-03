using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public int numberOfButtons = 4;

    public GameManager gm;
    public List<Upgrade> upgradesList = new List<Upgrade>();
    public Button[] upgradeButton = new Button[4];
    public Text[] upgradeButtonHeading = new Text[4];
    public Text[] upgradeButtonDescription = new Text[4];

    // Use this for initialization
    void Start () {
        upgradesList.Add(new Upgrade("Multi Ball", "Why not add another ball to the mix? What could go wrong?"));
        upgradesList.Add(new Upgrade("Add Target", "Let's give you something to aim at!"));
        upgradesList.Add(new Upgrade("Faster Return Speed", "About time we hired a ball boy!"));
        upgradesList.Add(new Upgrade("Less Return Delay", "How about we try paying ther ball boys a livable wage?"));

        LoadButtons();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadButtons(){
        for (int i = 0; i < numberOfButtons; i++)
        {
            upgradeButtonHeading[i].text = upgradesList[i].heading;
            upgradeButtonDescription[i].text = upgradesList[i].description;
        }
    }
}
[System.Serializable]
public struct Upgrade
{
    public string heading;
    public string description;
    public bool enabled;

    public Upgrade(string head, string desc)
    {
        heading = head;
        description = desc;
        enabled = false;
    }
}
