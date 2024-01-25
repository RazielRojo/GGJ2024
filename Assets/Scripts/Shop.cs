using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLuncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turrent Selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);

    }
    public void SelectMissleLuncher()
    {
        Debug.Log("Missle Luncher Selected");
        buildManager.SelectTurretToBuild(missileLuncher);

    }
}
