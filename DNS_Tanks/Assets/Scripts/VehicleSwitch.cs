using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("VehSwitchAvailable")]

public class VehicleSwitch : MonoBehaviour
{
    public int playerNumber = 0;

    public double cooldown = 3;
    private double timeStamp;

    private Vector3 center = Vector3.zero;
    public float radius = 0.5f;

    GameObject enteringPlayer;
    GameObject panel;
    internal bool menuAvailable;
    internal bool closeNow;

    void Start()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;
        center = transform.position;
        menuAvailable = false;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (other.transform.parent.tag == "Player " + playerNumber)
            {
                menuAvailable = true;
                closeNow = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (other.transform.parent.tag == "Player " + playerNumber)
            {
                menuAvailable = false;
                closeNow = true;
            }

        }
    }

    void Update()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;

        for (int i = 0; i <= 2; i++)
        { enteringPlayer = GameObject.FindGameObjectWithTag("Player " + playerNumber);
        if (enteringPlayer.GetComponentInChildren<VehSwitchAvailable>() != null)
        {
            enteringPlayer.GetComponentInChildren<VehSwitchAvailable>().menuAvailable = menuAvailable;
            enteringPlayer.GetComponentInChildren<VehSwitchAvailable>().closeNow = closeNow;
        }
        else
            return;
        }

        



        
        /*GameObject.FindGameObjectWithTag("Player " + playerNumber).GetComponentInChildren<VehSwitchAvailable>().menuAvailable = menuAvailable;
        GameObject.FindGameObjectWithTag("Player " + playerNumber).GetComponentInChildren<VehSwitchAvailable>().closeNow = closeNow;*/
    }


}