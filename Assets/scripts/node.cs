
using System;
using UnityEngine;

public class node : MonoBehaviour
{
    public Color hovercolor;
    public Vector3 positionoffset;
    private GameObject turret;
    private Renderer rend;
    private Color startcolor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret!=null)
        {
            Debug.Log("can't build here.");
            return;
        }

        GameObject turretToBuild = Buildmanager.instance.getturrettobuild();
       turret= (GameObject)Instantiate(turretToBuild, transform.position +positionoffset , transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
