using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtons : MonoBehaviour
{
    SuppliesAvailable p;
    Respawn respawn;
    GameObject player;
    GameObject parent;
    GameObject[] prefabs;


    public void Switch(int vehType)
    {
        player = GetComponentInParent<CurrentVehicle>().CurrentVehicleObject();
        if (gameObject.GetComponentInParent<VehSwitchAvailable>() && gameObject.GetComponentInParent<VehSwitchAvailable>().isOpen == true)
        {
            player.GetComponent<Vehicle>().ForVehicleChooseDestroy();
            respawn = gameObject.GetComponentInParent<Respawn>();
            respawn.startVehicle = vehType;
            respawn.RespawnPlayer();
            gameObject.GetComponentInParent<VehSwitchAvailable>().closeNow = true;
        }

    }

    public void ChooseSupply(int supply)
    {
        Vector3 offset = new Vector3(0f, 2f, 0f);
        player = GetComponentInParent<CurrentVehicle>().CurrentVehicleObject();
        p = gameObject.GetComponentInParent<SuppliesAvailable>();
        if (gameObject.GetComponentInParent<SuppliesAvailable>() && p.isOpen == true)
        {
            player.GetComponent<Vehicle>().SetSupply(player, offset, supply, prefabs);
            

            gameObject.GetComponentInParent<SuppliesAvailable>().closeNow = true;
            p.isOpen = false;
        }
    }

    private void Update()
    {
        
    }

}
