using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pausemenu : MonoBehaviour
{

    public GameObject ui;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        } 
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);//önemli.
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
            
        }
        else
        {
            Time.timeScale = 1f;
        }

         
    }
    public void retry()
    {
        Toggle();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu()
    {
        Debug.Log("go to menu");
    }
}
