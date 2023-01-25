using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstats : MonoBehaviour
{
    public static int Money;
    public int startmoney = 400;
    public static int lives;
    public int startlives = 20;

    private void Start()
    {
        Money = startmoney;
        lives = startlives;
    }
    
}
