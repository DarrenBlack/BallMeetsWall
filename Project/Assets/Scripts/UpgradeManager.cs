using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public int numberOfButtons = 1;

    public GameManager gm;
    public List<Upgrade> upgradesList = new List<Upgrade>();
    public List<UpgradeButtonScript> upgradeButtons = new List<UpgradeButtonScript>();

    // Use this for initialization
    void Start () {
        Upgrade FasterReturnSpeed = new Upgrade("Faster Return Speed", "About time we hired a ball boy!");
        FasterReturnSpeed.effect.ballReturnTime = -0.1f;
        upgradesList.Add(FasterReturnSpeed); 


        LoadButtons();
    }

    public void LoadButtons(){
        int loaded = 0; 
        while(loaded < upgradeButtons.Count && loaded < upgradesList.Count)
        {
            upgradeButtons[loaded].LoadNewUpgrade(upgradesList[loaded]);
            loaded++;
        }
    }
}
[System.Serializable]
public struct Upgrade
{
    public string heading;
    public string description;
    public bool enabled;
    public UpgradeEffect effect;


    public Upgrade(string head, string desc)
    {
        heading = head;
        description = desc;
        enabled = false;
        effect = new UpgradeEffect();
    }
}

[System.Serializable]
public struct UpgradeEffect
{
    public float ballSpeed;
    public float ballReturnTime;
    public float ballReturnDelay;
    public bool autoKick;
    public int noOfBalls;
    public float moneyMultiplier;
}
