
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class levelselector : MonoBehaviour
{
    public Button[] levelbuttons;
    //buttonları ekleme şansı elde ettik.


    public void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i+1>levelReached)
            {
                levelbuttons[i].interactable = false;
            }
           
        }
    }

    public void Select(string levelname)
    
    {
        SceneManager.LoadScene(levelname);
    }

}
