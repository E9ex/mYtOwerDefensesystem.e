using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]// inspectorda gizli olacak ve düzenli bir şekilde gösteriyor.
public class turretblueprint
{
   public GameObject prefab;
   public int cost;
   public GameObject upgradedprefab;
   public int upgradecost;

   public int getsellamount()
   {
      return cost/2;
   }

}
