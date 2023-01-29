using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Buildmanager : MonoBehaviour
{

    //referans olmadan bağlama çok fazla yapmamız gerekiyor yoksa hepsine teker teker atamamız gerekiyor./ singleton pattern

    public static Buildmanager instance;

    private void Awake()
    {
        instance = this;
    }

   

    private turretblueprint turretToBuild;
    public GameObject selleffect;
    public GameObject buildeffect;
    private node selectednode;
    public nodeuı Nodeıu;
    public bool canbuild
    {
        get { return turretToBuild != null; }
    } // property.

    public bool Hasmoney
    {
        get { return playerstats.Money >= turretToBuild.cost; }
    }

    

    public void selectnode(node _node)//e18/17:46
    {
        if (selectednode==_node)
        {
            deselectnode();
            return;
        }
        selectednode = _node;
        turretToBuild = null;
        
        Nodeıu.settarget(selectednode);
       
    }

    public void deselectnode()
    {
        selectednode = null;
        Nodeıu.hide();
    }

    public void selectturrettobuild(turretblueprint turret)
    {
        turretToBuild = turret;
        deselectnode();
    }

    public turretblueprint getTurretTobuild()
    {
        return turretToBuild;
    }

}
