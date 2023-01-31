using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public string leveltoload = "Mainlevel";
    
    public void play()
    {
        SceneManager.LoadScene(leveltoload);
    }

    public void quit()
    {
        Debug.Log("okey ı am quiting right now xx");
        Application.Quit();
    } 
}
