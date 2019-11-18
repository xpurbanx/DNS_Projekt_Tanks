using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("VehSwitchAvailable")]

public class VehicleSwitch : MonoBehaviour
{
    public double cooldown = 3;
    public float radius = 0.5f;
    public int playerNumber = 0;

    internal GameObject[] withPlayerTag;
    internal GameObject player;
    internal bool isInRadius;
    
    private GameObject vehicle;
    private PlayerInputSetup playerInput;
    private VehSwitchAvailable vehSwitch;
    private Vector3 center = Vector3.zero;
    private double timeStamp;

    void Awake()
    {
        RadiusSetUp();
        SetUp();
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject veh = vehicle.GetComponentInChildren<OverlayEnable>().gameObject;
        if (veh != null && other.gameObject.tag == "Player 1" || other.gameObject.tag == "Player 2")
        {
            veh.GetComponent<OverlayEnable>().isInRadiusOfStation = true;
            veh.GetComponent<OverlayEnable>().ShowHelpButtonPanel();
        }
    }

    void OnTriggerStay(Collider other)
    {
        timeStamp = vehSwitch.timeStamp;
        if (other.transform.parent != null && other.transform.parent.tag == "Player " + playerNumber && playerInput.BButton() && timeStamp < Time.time)
            vehSwitch.SwitchMenu();
    }

    void OnTriggerExit(Collider other)
    {
        timeStamp = vehSwitch.timeStamp;
        if (other.transform.parent != null && other.transform.parent.tag == "Player " + playerNumber && vehicle.GetComponentInChildren<VehSwitchAvailable>().isOpen == true)
            vehSwitch.CloseMenu();

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
                vehSwitch = vehicle.GetComponentInChildren<VehSwitchAvailable>();
                timeStamp = vehSwitch.timeStamp;
            }
        }
    }
}