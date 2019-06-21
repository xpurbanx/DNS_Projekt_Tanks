using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("VehSwitchAvailable")]

public class VehicleSwitch : MonoBehaviour
{
    internal GameObject[] withPlayerTag;
    internal GameObject player;
    public int playerNumber = 0;
    public double cooldown = 3;
    private double timeStamp;

    private Vector3 center = Vector3.zero;
    public float radius = 0.5f;

    GameObject panel;
    internal bool menuAvailable;
    internal bool closeNow;

    void Awake()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;
        center = transform.position;
        menuAvailable = false;

        withPlayerTag = GameObject.FindGameObjectsWithTag("Player " + playerNumber);
        for (int i = 0; i <= withPlayerTag.Length - 1; i++)
        {
            if (withPlayerTag[i].GetComponent<CamFollow>() && withPlayerTag[i].tag == "Player " + playerNumber) // Jeżeli jest to kamera TEGO gracza
            {
                player = withPlayerTag[i];
            }


        }
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


        if (player.GetComponentInChildren<VehSwitchAvailable>() != null)
        {
            player.GetComponentInChildren<VehSwitchAvailable>().menuAvailable = menuAvailable;
            player.GetComponentInChildren<VehSwitchAvailable>().closeNow = closeNow;
        }



    }


}