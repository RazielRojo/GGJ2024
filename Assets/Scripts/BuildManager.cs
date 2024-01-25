
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public NodeUI nodeUI;

    //singleton
    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("More than one BuildManager is in scene");
            return;
        }
        instance = this;
    }

    //public GameObject standartTurretPrefab;
    //public GameObject AnotherTurretPrefab;
    //public GameObject MissleLuncherPrefab;
    public GameObject BuildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStates.Money >= turretToBuild.cost; } }

    //public void BuildTurretOn(Node node)
    //{
    //    if (PlayerStates.Money < turretToBuild.cost)
    //    {
    //        Debug.Log("Not enought money to build that");
    //        return;
    //    }

    //    PlayerStates.Money -= turretToBuild.cost;

    //    //Build a turret in node 
    //    GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    //    node.turret = turret;

    //    GameObject effect = Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
    //    //destroy effect after 5 seconds
    //    Destroy(effect, 5f);

    //    Debug.Log("Turret build! Money left: " + PlayerStates.Money);

    //}

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(selectedNode);
    }

    public void DeselectNode()
    {
        nodeUI.hide();
        selectedNode = null;
        
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
