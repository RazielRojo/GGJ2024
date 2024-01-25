
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    //[Header("optional")]
    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (turret != null)
        {
            //Debug.Log("Can't build ther - TODO display on screen.");
            buildManager.SelectNode(this);
            return;
        }


        if (!buildManager.CanBuild)
            return;

        //buildManager.BuildTurretOn(this);
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStates.Money < blueprint.cost)
        {
            Debug.Log("Not enought money to build that");
            return;
        }

        PlayerStates.Money -= blueprint.cost;

        //Build a turret in node 
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
        //destroy effect after 5 seconds
        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStates.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enought money to upgrade that");
            return;
        }

        PlayerStates.Money -= turretBlueprint.upgradeCost;
        //get rid of the old turret 
        Destroy(turret);

        //Build a new one
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = Instantiate(buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
        //destroy effect after 5 seconds
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
