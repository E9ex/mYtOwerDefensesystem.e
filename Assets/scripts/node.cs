
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    public Color hovercolor;
    public Color notenoughmoney=Color.red;
    public Vector3 positionoffset;
    
    [HideInInspector]
    public GameObject turret;

    [HideInInspector] 
    public turretblueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;
    
    
    private Renderer rend;
    private Color startcolor;
    private Buildmanager _Buildmanager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        _Buildmanager = Buildmanager.instance;
    }

    public Vector3 getbuildposition()
    {
        return transform.position + positionoffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
       
        if (turret!=null)
        {
            _Buildmanager.selectnode(this);
            return;
        }
        if (!_Buildmanager.canbuild)
        {
            return;
        }

        buildturret(Buildmanager.instance.getTurretTobuild());
        //Buildmanager.instance.buildturreton(this);
    }


    void buildturret(turretblueprint blueprint)
    {
        if (playerstats.Money<blueprint.cost)
        {
            Debug.Log("not enough money to build that.");
            return;
        }

        playerstats.Money -= blueprint.cost;
        GameObject _turret=(GameObject) Instantiate(blueprint.prefab, getbuildposition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
        GameObject effect=(GameObject)Instantiate(Buildmanager.instance.buildeffect, getbuildposition(), Quaternion.identity);
        Debug.Log("turret build ");
    }

    public void upgradeturret()
    {
        if (playerstats.Money<turretBlueprint.upgradecost)
        {
            Debug.Log("not enough money to upgrade that.");
            return;
        }

        playerstats.Money -= turretBlueprint.upgradecost;
        //eskisinden kurtuluyoruz.
        Destroy(turret);
        //yenisi 
        GameObject _turret=(GameObject) Instantiate(turretBlueprint.upgradedprefab, getbuildposition(), Quaternion.identity);
        turret = _turret;
        
        GameObject effect=(GameObject)Instantiate(Buildmanager.instance.buildeffect, getbuildposition(), Quaternion.identity);
        Destroy(effect, 5f);
        isUpgraded = true;
        Debug.Log("turret upgraded. ");
    }

    public void sellturret()
    {
        playerstats.Money += turretBlueprint.getsellamount();
        GameObject effect=(GameObject)Instantiate(Buildmanager.instance.selleffect, getbuildposition(), Quaternion.identity);

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())//turret seçerken nodelara basmayalım diye. üst üste gelirse.
        {
            return;
        }
        if (!_Buildmanager.canbuild)
        {
            return;
        }

        if (_Buildmanager.Hasmoney)
        {
            rend.material.color = hovercolor;

        }
        else
        {
            rend.material.color = notenoughmoney;
        }
        
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
