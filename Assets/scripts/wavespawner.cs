using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public gamemanager Gamemanager;
    public static int enemiesalive = 0;
    public wave[] waves;

    public Transform spawnpoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0; //waveındex
    public TextMeshProUGUI wavecountdowntext;


    private void Update()
    {
        if (enemiesalive > 0)
        {
            return;
        }

      /*  if (waveIndex == waves.Length)
        {
            Gamemanager.winlevel();
            this.enabled = false;
            
        }*/

        if (countdown <= 0f)
        {
            StartCoroutine(spawnwave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); // not less than zero.
        wavecountdowntext.text = string.Format("{0:00.00}", countdown); // saliseye kadar göstemeye yarıyor.
    }

    IEnumerator spawnwave()
    {

        playerstats.rounds++;
        wave wavee = waves[waveIndex];
        enemiesalive = wavee.count;
        for (int i = 0; i < wavee.count; i++)
        {
            spawnenemy(wavee.enemy);
            yield return new WaitForSeconds(1f / wavee.rate);
        }

        waveIndex++;
        if (waveIndex == waves.Length)
        {
            Gamemanager.winlevel();
            this.enabled = false;
            
        }
    }




    void spawnenemy(GameObject enemy)
    {
        
        Instantiate(enemy,spawnpoint.position,spawnpoint.rotation);
        
    }
}
