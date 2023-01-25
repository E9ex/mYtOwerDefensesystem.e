 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int value = 50;
        private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = waypoints.points[0];
    }

    public void Takedamage(int amount)
    {
        health -= amount;
        if (health <= 0)
            die();
    }

    void die()
    {
        playerstats.Money += value;
        Destroy(gameObject);
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized* speed * Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position,target.position)<=0.4f)
        {
            getnextwaypoint();
        }
    }

    void getnextwaypoint()
    {
        if (wavepointIndex>=waypoints.points.Length-1)
            
        {
            Endpath();
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
        
    }

    void Endpath()
    {
        playerstats.lives--;
        Destroy(gameObject);

    }
}
