using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class moneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneytext;


    private void Update()
    {

        moneytext.text = "$"+playerstats.Money.ToString();
    }
}
