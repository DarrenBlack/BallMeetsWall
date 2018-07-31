using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Text moneyDisplay;
    public Text moneyPSDisplay;
    public Text fansDisplay;
    public Text fansPSDisplay;
    public Text stageDisplay;    

    public float money = 0;
    public float moneyPS = 0;
    public float fans = 0;
    public float fansPS = 0;

    public float moneyPerGoal = 1;

    public string stageName;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moneyDisplay.text = "£: " + money;
        moneyPSDisplay.text = "£PS: " + moneyPS;
        fansDisplay.text = "Fans: " + fans;
        fansPSDisplay.text = "FansPS: " + fansPS;
        stageDisplay.text = "Stage: " + stageName;
	}
}
