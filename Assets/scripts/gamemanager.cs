using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public static bool gameisover = false;
    public GameObject gameoveruı;
    public GameObject completeUI;

    private void Start()
    {
        gameisover = false;
    }

    void Update()
    {
        if (gameisover)
        {
            return;
        }

        if (Input.GetKeyDown("b"))
            
        {
            Endgame();
        }
        if (playerstats.lives<=0)
        {
            Endgame();
        }
    }

    void Endgame()

    {
        gameisover = true;
        gameoveruı.SetActive(true);
        
    }

    public void winlevel()
    {
        gameisover = true;
        Debug.Log("YOU WON");
        completeUI.SetActive(true);
        
    }
    
}
