using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnpoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;//waveındex
    public TextMeshProUGUI wavecountdowntext;
    

    private void Update()
    {
        if (countdown<=0f)
        {
            StartCoroutine(spawnwave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        wavecountdowntext.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnwave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            spawnenemy();
            yield return new WaitForSeconds(0.5f);
        }
        
       // Debug.Log("wave incoming");
       
    }

    void spawnenemy()
    {
        Instantiate(enemyPrefab,spawnpoint.position,spawnpoint.rotation);
    }
}
