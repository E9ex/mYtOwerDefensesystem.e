using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
   public turretblueprint standardturret;
   public turretblueprint missilelauncher;
   Buildmanager buildManager;

   private void Start()
   {
      buildManager = Buildmanager.instance;
   }

   public void selectedstandardturret()
   {
      Debug.Log("standard turret purchased.");
      buildManager.selectturrettobuild(standardturret);
   }
   public void selectmissilelauncher()
   {
      Debug.Log("missile launcher purchased.");
      buildManager.selectturrettobuild(missilelauncher);
   }
}
