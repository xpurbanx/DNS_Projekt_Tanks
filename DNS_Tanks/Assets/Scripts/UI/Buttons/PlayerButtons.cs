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
            gameObject.GetComponent<VehSwitchAvailable>().CloseMenu();
            respawn.RespawnPlayer();
            
        }

    }

    public void ChooseSupply(int supply)
    {
        player = GetComponentInParent<CurrentVehicle>().CurrentVehicleObject();
        
        suppliesAvailable = gameObject.GetComponent<SuppliesAvailable>();
        
        ///////////////////////////////////////////////////////////////////////////
        if (suppliesAvailable != null && suppliesAvailable.isOpen == true)
        {
            playerNumber = player.GetComponentInChildren<PlayerFiring>().playerNumber;
            Vector3 position = GameObject.FindGameObjectWithTag("Supply Holder " + playerNumber).transform.position;
            prefabs = suppliesAvailable.prefabs;
            prefab = prefabs[supply];
            suppliesAvailable.CloseMenu();
            player.GetComponent<Vehicle>().SetSupply(position, prefab);
        }
    }

}
