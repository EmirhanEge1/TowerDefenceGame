
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missleTurret;
    public TurretBlueprint laserTurret;


    BuildManager buildManager;
    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("purchase standard complete");
        buildManager.SetTurretToBuild(standartTurret);
    }
    public void SelectMissleTurret()
    {
        Debug.Log("purchase missle complete");
        buildManager.SetTurretToBuild(missleTurret);

    }
    public void SelectLaserTurret()
    {
        Debug.Log("purchase laser complete");
        buildManager.SetTurretToBuild(laserTurret);

    }


}
