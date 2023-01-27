using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform target;
    private enemy targetenemy;

    [Header("general")]
   
    public float range = 15f;
    [Header("use bullet (default)")]
    public GameObject bulletprefab;
    public  float fireRate=1f;
    private float fireCountdown = 0f;

    [Header("use laser (default)")] 
    public bool uselaser = false;

    public float slowamount = .5f;
    public int Damageovertime = 30;
    public LineRenderer lineRenderer;
    public ParticleSystem impacteffect;
    public Light impactlight;
    
    [Header("unity setup fields")]
    public Transform PartToRotate;
    public string enemytag = "enemy";
    public float turnspeed=10f;
    

    public Transform firepoint;
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
            targetenemy = nearestEnemy.GetComponent<enemy>();
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
            if (uselaser)
            {

                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impacteffect.Stop();
                    impactlight.enabled = false;
                }
            }
            
            return; }
        //target lock on.
        lockontarget();
        if (uselaser)
        {
            laser();
        }
        else
        {
            if (fireCountdown<=0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        
        
        
    }

    void lockontarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir); //rotation
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void laser()
    {
        targetenemy.Takedamage(Damageovertime*Time.deltaTime);
        targetenemy.slow(slowamount);
        if (!lineRenderer.enabled)
        {//e17 tekrar izle 18.29
            lineRenderer.enabled = true;
            impacteffect.Play();
            impactlight.enabled = true;
        }
        lineRenderer.SetPosition(0,firepoint.position);
        lineRenderer.SetPosition(1,target.position);
        Vector3 dir = firepoint.position - target.position;//b-a ::
        impacteffect.transform.position = target.position+dir.normalized;
        impacteffect.transform.rotation = Quaternion.LookRotation(dir); //yönü o tarafa çekmesini sağlıyor.
    }

    
    

    void Shoot()
    {
        GameObject bulletGo=(GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        bullet bullet = bulletGo.GetComponent<bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    } 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
