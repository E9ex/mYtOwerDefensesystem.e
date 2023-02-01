 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Serialization;

 public class enemy : MonoBehaviour
{
   public float  startspeed=10f;
   [HideInInspector]
    public float speed = 10f;
    
    
    public float health = 100;
    public int worth = 50;
    private bool isdead = false;

    private void Start()
    {
        speed = startspeed;
    }

    public void Takedamage(float amount)
    {
        health -= amount;
        if (health <= 0&& !isdead)
            die();
    }

    
    public void slow(float pct)
    {
        speed = startspeed * (1f - pct);
    }

    void die()
    {
        isdead = true;
        
        playerstats.Money += worth;
        wavespawner.enemiesalive--;
        Destroy(gameObject);
    
    }
    
}
