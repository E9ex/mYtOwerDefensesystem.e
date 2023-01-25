using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    private bool gameended = false;

    // Update is called once per frame
    void Update()
    {
        if (gameended)
        {
            return;
        }
        if (playerstats.lives<=0)
        {
            Endgame();
        }
    }

    void Endgame()

    {
        gameended = true;
        Debug.Log("game over ");
        
    }
    
}
