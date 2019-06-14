using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Buttons : MonoBehaviour
{
    Respawn respawn;

    public void Jeep1()
    {
        gameObject.GetComponentInParent<Vehicle>().ForVehicleChooseDestroy();
        respawn = gameObject.GetComponentInParent<Respawn>();
        respawn.startVehicle = 1;
        respawn.Launch();
    }
}
