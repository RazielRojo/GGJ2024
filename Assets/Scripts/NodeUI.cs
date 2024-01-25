using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    
    public void SetTarget(Node _target)
    {

        target = _target;
        transform.position = _target.GetBuildPosition();
        ui.SetActive(true);
    }
    public void hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
