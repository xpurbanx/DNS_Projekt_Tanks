using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Buttons : MonoBehaviour
{
    Respawn respawn;
    GameObject player;
    GameObject[] withPlayerTag;


    public void Jeep1()
    {
        withPlayerTag = GameObject.FindGameObjectsWithTag("Player 1");
        for (int i = 0; i <= withPlayerTag.Length - 1; i++)
        {
            if (withPlayerTag[i].GetComponent<PlayerFiring>() && withPlayerTag[i].tag == "Player 1") // Jeżeli jest to KONKRETNIE pojazd tego gracza
                player = withPlayerTag[i];
        }

        if (gameObject.GetComponentInParent<VehSwitchAvailable>() && gameObject.GetComponentInParent<VehSwitchAvailable>().isOpen == true)
        {
            player.GetComponent<Vehicle>().ForVehicleChooseDestroy();
            respawn = gameObject.GetComponentInParent<Respawn>();
            respawn.startVehicle = 1;
            respawn.RespawnPlayer();
            gameObject.GetComponentInParent<VehSwitchAvailable>().closeNow = true;
        }

    }
}
