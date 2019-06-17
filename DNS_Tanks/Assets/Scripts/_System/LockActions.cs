using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockActions : MonoBehaviour
{
    Vehicle veh;

    void Update()
    {
        Construct();
    }

    public void SwitchShooting()
    {
        if (veh != null)
            veh.GetComponent<PlayerFiring>().locked = !veh.GetComponent<PlayerFiring>().locked;
    }

    public void TrueShooting()
    {
        if (veh != null)
            veh.GetComponent<PlayerFiring>().locked = false;
    }

    public void FalseShooting()
    {
        if (veh != null)
            veh.GetComponent<PlayerFiring>().locked = true;
    }

    public void SwitchMovement()
    {
        if (veh != null)
            veh.GetComponent<PlayerMovement>().locked = !veh.GetComponent<PlayerMovement>().locked;
    }

    public void TrueMovement()
    {
        if (veh != null)
            veh.GetComponent<PlayerMovement>().locked = false;
    }

    public void FalseMovement()
    {
        if (veh != null)
            veh.GetComponent<PlayerMovement>().locked = true;
    }

    void Construct()
    {
        veh = transform.GetChild(0).GetComponent<Vehicle>();
    }
}
