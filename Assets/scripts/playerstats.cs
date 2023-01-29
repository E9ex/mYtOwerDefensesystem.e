using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstats : MonoBehaviour
{
    public static int Money;
    public int startmoney = 400;
    public static int lives;
    public int startlives =20;
    public  static int rounds;

    private void Start()
    {
        Money = startmoney;
        lives = startlives;
        rounds = 0;//why we do is write zero in here if we dont write zero it wont reset 
    }
    
}
