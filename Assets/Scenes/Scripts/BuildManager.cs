using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake() {
        if(instance != null)
        {
            Debug.LogError("More than one builder");
                return;
        }
        instance = this;
    }


    private TurretBlueprint turretToBuild;
    private Node selectedTurret;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public GameObject buildEffect;

    
    public void SelectNode (Node node)
    {
        if (selectedTurret == node) {
            DeselectNode();
            return;
        }

        selectedTurret = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedTurret = null;
        nodeUI.Hide();

    }
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();

            }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
