
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    public Color hovercolor;
    public Color notenoughmoney=Color.red;
    public Vector3 positionoffset;
    
    [Header("optional")]
    public GameObject turret;
    
    
    
    private Renderer rend;
    private Color startcolor;
    private Buildmanager _Buildmanager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        _Buildmanager = Buildmanager.instance;
    }

    public Vector3 getbuildposition()
    {
        return transform.position + positionoffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!_Buildmanager.canbuild)
        {
            return;
        }
        if (turret!=null)
        {
            Debug.Log("can't build here.");
            return;
        }

        Buildmanager.instance.buildturreton(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())//turret seçerken nodelara basmayalım diye. üst üste gelirse.
        {
            return;
        }
        if (!_Buildmanager.canbuild)
        {
            return;
        }

        if (_Buildmanager.Hasmoney)
        {
            rend.material.color = hovercolor;

        }
        else
        {
            rend.material.color = notenoughmoney;
        }
        
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
