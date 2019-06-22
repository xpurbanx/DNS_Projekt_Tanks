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

    internal GameObject[] withPlayerTag;
    internal GameObject player;
    GameObject panel;
    GameObject vehicle;

    PlayerInputSetup playerInput;
    VehSwitchAvailable vehSwitch;

    private Vector3 center = Vector3.zero;
    public float radius = 0.5f;

<<<<<<< HEAD
    void Awake()
    {
        RadiusSetUp();
        SetUp();
=======
    GameObject panel;
    internal bool menuAvailable;
    internal bool closeNow;

    void Start()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;
        center = transform.position;
        menuAvailable = false;
>>>>>>> parent of 3a6fbeb... Request #48 (Mix zmian Michała, Mikołaja i moich, rozwiązane konflikty i naprawione małe bugi)
    }

    void OnTriggerStay(Collider other)
    {
        timeStamp = vehSwitch.timeStamp;
        if (other.transform.parent != null && other.transform.parent.tag == "Player " + playerNumber && playerInput.XButton() && timeStamp < Time.time)
            vehSwitch.SwitchMenu();
    }

    void OnTriggerExit(Collider other)
    {
        timeStamp = vehSwitch.timeStamp;
        if (other.transform.parent != null && other.transform.parent.tag == "Player " + playerNumber && vehicle.GetComponentInChildren<VehSwitchAvailable>().isOpen == true)
            vehSwitch.CloseMenu();
    }

    void RadiusSetUp()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;
        center = transform.position;
    }

<<<<<<< HEAD
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
=======
        //GameObject.FindGameObjectWithTag("Player " + playerNumber).GetComponentInChildren<VehSwitchAvailable>().menuAvailable = menuAvailable;
        //GameObject.FindGameObjectWithTag("Player " + playerNumber).GetComponentInChildren<VehSwitchAvailable>().closeNow = closeNow;
>>>>>>> parent of 3a6fbeb... Request #48 (Mix zmian Michała, Mikołaja i moich, rozwiązane konflikty i naprawione małe bugi)
    }
}