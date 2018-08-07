using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonScript : MonoBehaviour {

    public GameManager gm;
    public UpgradeEffect effect;
    public string heading;
    public string description;

    public Text headingDisplay;
    public Text descriptionDisplay;

    public void LoadNewUpgrade(Upgrade newUpgrade)
    {
        headingDisplay.text = newUpgrade.heading;
        descriptionDisplay.text = newUpgrade.description;
        effect = newUpgrade.effect;
    }

    public void ApplyUpgrade()
    {
        gm.ApplyUpgrade(effect);
    }   
}
