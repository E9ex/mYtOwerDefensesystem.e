using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvive : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    private void OnEnable() //every time object get enabled.
    {
        StartCoroutine(Animatetext());
    }

    IEnumerator Animatetext()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(.7f);
        while (round<playerstats.rounds)
        {
            round++;
            roundsText.text = round.ToString();//
            yield return new WaitForSeconds(.05f);
            
        }
    }
}
