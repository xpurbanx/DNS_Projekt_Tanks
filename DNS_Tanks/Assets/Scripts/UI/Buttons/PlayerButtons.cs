using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]

public class PlayerButtons : MonoBehaviour
{
    SuppliesAvailable suppliesAvailable;
    Respawn respawn;
    internal GameObject player, prefab, parent;
    List<GameObject> prefabs;
    int playerNumber;


    public void Switch(int vehType)
    {
        player = GetComponentInParent<CurrentVehicle>().CurrentVehicleObject();
        if (gameObject.GetComponent<VehSwitchAvailable>() && gameObject.GetComponentInParent<VehSwitchAvailable>().isOpen == true)
        {
            player.GetComponent<Vehicle>().ForVehicleChooseDestroy();
            respawn = gameObject.GetComponentInParent<Respawn>();
            respawn.startVehicle = vehType;
            respawn.RespawnPlayer();
            gameObject.GetComponent<VehSwitchAvailable>().SwitchMenu();
        }

    }

    public void ChooseSupply(int supply)
    {
        player = GetComponentInParent<CurrentVehicle>().CurrentVehicleObject();
        playerNumber = player.GetComponentInChildren<PlayerFiring>().playerNumber;
        suppliesAvailable = gameObject.GetComponent<SuppliesAvailable>();
        
        ///////////////////////////////////////////////////////////////////////////
        if (suppliesAvailable != null && suppliesAvailable.isOpen == true)
        {
            Vector3 position = GameObject.FindGameObjectWithTag("Supply Holder " + playerNumber).transform.position;
            prefabs = suppliesAvailable.prefabs;
            prefab = prefabs[supply];
            player.GetComponent<Vehicle>().SetSupply(position, prefab);
            suppliesAvailable.SwitchMenu();
        }
    }

}
