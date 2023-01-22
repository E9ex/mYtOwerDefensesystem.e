using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildmanager : MonoBehaviour
{

    //referans olmadan bağlama çok fazla yapmamız gerekiyor yoksa/ singleton pattern
    
    public static Buildmanager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject standardturretprefab;

    private void Start()
    {
        turretToBuild = standardturretprefab;
    }

    private GameObject turretToBuild;

    public GameObject getturrettobuild()
    {
        return turretToBuild;
    }

}
