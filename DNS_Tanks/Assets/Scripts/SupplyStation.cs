﻿using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("SuppliesAvailable")]

public class SupplyStation : MonoBehaviour
{
    public int playerNumber = 0;
    public double cooldown = 3;
    public int stationType = 1;
    internal double timeStamp;

    internal GameObject[] withPlayerTag;
    internal GameObject player;
    GameObject panel;
    GameObject vehicle;

    PlayerInputSetup playerInput;
    SuppliesAvailable supp;

    private Vector3 center = Vector3.zero;
    public float radius = 0.5f;

    void Awake()
    {
        RadiusSetUp();
        SetUp();
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject veh = vehicle.GetComponentInChildren<OverlayEnable>().gameObject;
        if (veh != null && other.gameObject.tag == "Player " + playerNumber)
        {
            veh.GetComponent<OverlayEnable>().isInRadiusOfStation = true;
            veh.GetComponent<OverlayEnable>().ShowHelpButtonPanel(stationType, vehicle.GetComponentInChildren<Vehicle>().vehType);
        }
    }

    void OnTriggerStay(Collider other)
    {
        timeStamp = supp.timeStamp;
        if (other.transform.parent != null && other.transform.parent.tag == "Player " + playerNumber && playerInput.XButton() && timeStamp < Time.time)
            supp.SwitchMenu();
    }

    void OnTriggerExit(Collider other)
    {
        timeStamp = supp.timeStamp;
        if (other.transform.parent != null && other.transform.parent.tag == "Player " + playerNumber && vehicle.GetComponentInChildren<SuppliesAvailable>().isOpen == true)
            supp.CloseMenu();

        GameObject veh = vehicle.GetComponentInChildren<OverlayEnable>().gameObject;
        if (veh != null && other.gameObject.tag == "Player 1" || other.gameObject.tag == "Player 2")
        {
            veh.GetComponent<OverlayEnable>().isInRadiusOfStation = false;
            veh.GetComponent<OverlayEnable>().HideHelpButtonPanel();
        }
    }

    void RadiusSetUp()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;
        center = transform.position;
    }

    void SetUp()
    {
        withPlayerTag = GameObject.FindGameObjectsWithTag("Player " + playerNumber);
        for (int i = 0; i <= withPlayerTag.Length - 1; i++)
        {
            if (withPlayerTag[i].GetComponent<Respawn>() && withPlayerTag[i].tag == "Player " + playerNumber)
            {
                vehicle = withPlayerTag[i];
                playerInput = vehicle.GetComponent<PlayerInputSetup>();
                supp = vehicle.GetComponentInChildren<SuppliesAvailable>();
                timeStamp = supp.timeStamp;
            }
        }
    }
}