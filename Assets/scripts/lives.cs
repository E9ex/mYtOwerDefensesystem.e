using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

using UnityEngine;

public class lives : MonoBehaviour
{
    public TextMeshProUGUI livestext;
    

    // Update is called once per frame
    void Update()
    {
        livestext.text = playerstats.lives+"LIVES";
    }
}
