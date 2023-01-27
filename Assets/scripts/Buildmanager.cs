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

    public void buildturreton(node _node)
    {
        if (playerstats.Money<turretToBuild.cost)
        {
            Debug.Log("not enough money to build that.");
            return;
        }

        playerstats.Money -= turretToBuild.cost;
       GameObject turret=(GameObject) Instantiate(turretToBuild.prefab, _node.getbuildposition(), Quaternion.identity);
       _node.turret = turret;
       GameObject effect=(GameObject)Instantiate(buildeffect, _node.getbuildposition(), Quaternion.identity);
       Destroy(effect, 5f);
       Debug.Log("turret build money left:"+playerstats.Money);
       
    }

    public void selectnode(node _node)//e18/17:46
    {
        selectednode = _node;
        turretToBuild = null;
        Nodeıu.settarget(selectednode);
       
    }

    public void selectturrettobuild(turretblueprint turret)
    {
        turretToBuild = turret;
        selectednode = null;
    }
    
}
