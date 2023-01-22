using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public GameObject impacteffect;

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

    }

    void Hittarget()
    {
        GameObject efffecins=(GameObject)Instantiate(impacteffect, transform.position, transform.rotation);
        Destroy(efffecins,2f);
        Destroy(gameObject);
    }
}
