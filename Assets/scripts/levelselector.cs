
using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class levelselector : MonoBehaviour
{
    
    public void Select(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

}
