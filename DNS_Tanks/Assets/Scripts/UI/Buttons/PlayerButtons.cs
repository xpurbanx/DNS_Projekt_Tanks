using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtons : MonoBehaviour
{
    SuppliesAvailable suppliesAvailable;
    Respawn respawn;
    GameObject player;
    GameObject parent;
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
        if (suppliesAvailable && suppliesAvailable.isOpen == true)
        {
            Vector3 position = GameObject.FindGameObjectWithTag("Supply Holder " + playerNumber).transform.position;
            prefabs = suppliesAvailable.prefabs;
            GameObject prefab = prefabs[supply];
            player.GetComponent<Vehicle>().SetSupply(player, position, supply, prefab);
            suppliesAvailable.SwitchMenu();
        }
    }

}
