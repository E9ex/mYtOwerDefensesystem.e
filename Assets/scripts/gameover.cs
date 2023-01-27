using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameover : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable() //every time object get enabled.
    {
        roundsText.text = playerstats.rounds.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu()
    {
        Debug.Log("go to menu");
    }
}
