using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrroler : MonoBehaviour
{
    public float panborderthickness = 10f;
    public float panspeed = 30f;
    private bool domovement = true;
    public float scrollspeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    public void Update()
    {
        if (gamemanager.gameisover)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            domovement = !domovement;
        }
        if (!domovement)
        {
            return;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panborderthickness) 
        {

            transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panborderthickness) 
        {

            transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.height - panborderthickness) 
        {

            transform.Translate(Vector3.back * panspeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panborderthickness) 
        {

            transform.Translate(Vector3.forward * panspeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("l") ) 
        {

            transform.Translate(Vector3.up * panspeed * Time.deltaTime, Space.World);

        }
        if (Input.GetKey("o") ) 
        {

            transform.Translate(Vector3.down * panspeed * Time.deltaTime, Space.World);

        }

        float scroll=Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000*scrollspeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);//scrollun high ve lowunu belirleyecek.
        transform.position = pos;
    }
}
