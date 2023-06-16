
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missleTurret;
    public TurretBlueprint laserTurret;
    public TurretBlueprint cannonTurret;



    BuildManager buildManager;
    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(standartTurret);
    }

    public void SelectCannonTurret()
    {
        buildManager.SetTurretToBuild(cannonTurret);

    }
    public void SelectMissleTurret()
    {
        buildManager.SetTurretToBuild(missleTurret);

    }
    public void SelectLaserTurret()
    {
        buildManager.SetTurretToBuild(laserTurret);

    }
   

}
