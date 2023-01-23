using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildmanager : MonoBehaviour
{

    //referans olmadan bağlama çok fazla yapmamız gerekiyor yoksa hepsine teker teker atamamız gerekiyor./ singleton pattern

    public static Buildmanager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject standardturretprefab;
    public GameObject missilelauncherprefab;

    private turretblueprint turretToBuild;

    public bool canbuild
    {
        get { return turretToBuild != null; }
    } // property.

    public void buildturreton(node _node)
    {
       GameObject turret=(GameObject) Instantiate(turretToBuild.prefab, _node.getbuildposition(), Quaternion.identity);
       _node.turret = turret;
    }

    public void selectturrettobuild(turretblueprint turret)
    {
        turretToBuild = turret;
    }
}
