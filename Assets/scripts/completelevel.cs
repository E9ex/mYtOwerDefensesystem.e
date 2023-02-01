using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class completelevel : MonoBehaviour
{
    public string menuscenemName = "Mainmenu";
    public string nextlevel = "Mainlevel 2";
    public int leveltoUnlock = 2;
    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached",leveltoUnlock);
        SceneManager.LoadScene(nextlevel);
    }

    public void Menu()
    {
        
        SceneManager.LoadScene(menuscenemName);
    }
    
}
