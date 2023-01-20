using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform target;
    public float turnspeed=10f;
    public float range = 15f;
    public Transform PartToRotate;
    public string enemytag = "enemy";
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updatetarget",0f,0.5f);
    }

    void updatetarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestdistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distancetoenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoenemy<shortestdistance)
            {
                shortestdistance = distancetoenemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy!=null&& shortestdistance<=range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
            
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target==null)
        {
            return; }
        //target lock on.
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); //rotation
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
