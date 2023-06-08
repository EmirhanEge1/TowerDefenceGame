using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    public Node target;
    public Vector3 positionOffset;
    public Text upgradeCost;
    public Button UpgradeButton;

    public void SetTarget (Node target)
    {
        this.target = target;
        transform.position = target.GetBuildPosition() + positionOffset;
        if (!target.isUpgraded) { 
            upgradeCost.text = "$"+target.turretBlueprint.upgradeCost;
            UpgradeButton.interactable = true;
        }

        else
        {
            upgradeCost.text = "Upgraded";
            UpgradeButton.interactable = false;

        }
        ui.SetActive(true);
     
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade ()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

}
