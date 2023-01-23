using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public GameObject impacteffect;
    public float explosionradius = 0;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        // find new target
        if (target == null)
        {
            Destroy(gameObject);
                return;
        }
            
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)// bunu yazmazsak overshoot olur.
        {
            Hittarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame,Space.World);//speedin fark yaratmaması için obje üzerinde.
        
        transform.LookAt(target);// missile in target düz bakmasını  sağlıyor.

    }

    void Hittarget()
    {
        GameObject efffecins=(GameObject)Instantiate(impacteffect, transform.position, transform.rotation);
        if (explosionradius>0f)
        {
            explode();
        }
        else
        {
         damage(target);   
        }
        Destroy(efffecins,2f);
        Destroy(gameObject);
    }

    void explode()
    {
       Collider[] colliders= Physics.OverlapSphere(transform.position, explosionradius);
       foreach (Collider collider in colliders)
       {
          if(collider.tag == "enemy")
              damage(collider.transform);//10 dk 10.bölüm
       }
    }

    void damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionradius);
    }
}
