using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class nodeuı : MonoBehaviour
{
    public GameObject ui;
    private node target;
    public TextMeshProUGUI upgradecost;
    public Button upgradebutton;
    public TextMeshProUGUI sellamount;

    public void settarget(node _target)
    {
        target = _target;
        
        transform.position = target.getbuildposition();
        if (!target.isUpgraded)
        {
            upgradecost.text = "$"+ target.turretBlueprint.upgradecost.ToString();
            upgradebutton.interactable = true;

        }
        else
        {
            upgradecost.text="done";
            upgradebutton.interactable = false;

        }

        sellamount.text = "$" + target.turretBlueprint.getsellamount();//upgrade edicek fiyati.
        ui.SetActive(true);
       
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void upgrade()
    {
        target.upgradeturret();
        Buildmanager.instance.deselectnode();
    }

    public void sell()
    {
        target.sellturret();
        Buildmanager.instance.deselectnode();
    }
}
