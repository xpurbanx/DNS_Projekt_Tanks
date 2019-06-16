using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtons : MonoBehaviour
{
    SuppliesAvailable p;
    Respawn respawn;
    GameObject player;
    GameObject parent;
    List<GameObject> prefabs;


    public void Switch(int vehType)
    {
        player = GetComponentInParent<CurrentVehicle>().CurrentVehicleObject();
        if (gameObject.GetComponent<VehSwitchAvailable>() && gameObject.GetComponentInParent<VehSwitchAvailable>().isOpen == true)
        {
            player.GetComponent<Vehicle>().ForVehicleChooseDestroy();
            respawn = gameObject.GetComponentInParent<Respawn>();
            respawn.startVehicle = vehType;
            respawn.RespawnPlayer();
            gameObject.GetComponent<VehSwitchAvailable>().closeNow = true;
        }

    }

    public void ChooseSupply(int supply)
    {
        player = GetComponentInParent<CurrentVehicle>().CurrentVehicleObject();
        p = gameObject.GetComponent<SuppliesAvailable>();
        if (GetComponent<SuppliesAvailable>() && p.isOpen == true)
        {
            prefabs = gameObject.GetComponent<SuppliesAvailable>().prefabs;
            GameObject prefab = prefabs[supply];
            Vector3 offset = new Vector3(-3f, 1.25f, 3f);
            player.GetComponent<Vehicle>().SetSupply(player, offset, supply, prefab);
            GetComponent<SuppliesAvailable>().OpenMenu();
        }
    }

}
