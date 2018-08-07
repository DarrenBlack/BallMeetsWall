using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Text moneyDisplay;
    public Text moneyPKDisplay;
    public Text moneyPSDisplay;
    public Text fansDisplay;
    public Text fansPKDisplay;
    public Text fansPSDisplay;
    public Text stageDisplay;    
    
    
    //Currency Values
    public float money = 0;
    public float moneyPK = 1;
    public float moneyPS = 0;
    public float fans = 0;
    public float fansPK = 0;
    public float fansPS = 0;

    public string stageName;

    //Ball Values
    public float ballSpeed;
    public float ballReturnDelay;
    public float ballReturnTime;

    public bool autoKick; //NOT YET IMPLEMENTED
    public int noOfBalls; //NOT YET IMPLEMENTED




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moneyDisplay.text = "£: " + money;
        moneyPKDisplay.text = "£ Per Kick:" + moneyPK;
        moneyPSDisplay.text = "£PS: " + moneyPS;

        fansDisplay.text = "Fans: " + fans;
        fansPKDisplay.text = "Fans Per Kick:" + fansPK;
        fansPSDisplay.text = "FansPS: " + fansPS;
        stageDisplay.text = "Stage: " + stageName;
	}

    public void ApplyUpgrade(UpgradeEffect effect)
    {
        ballSpeed += effect.ballSpeed;
        ballReturnTime += effect.ballReturnTime;
        ballReturnTime += effect.ballReturnDelay;
        noOfBalls += effect.noOfBalls;
        moneyPK += effect.moneyMultiplier;

        if (!autoKick)
        {
            autoKick = effect.autoKick;
        }
    }
}
