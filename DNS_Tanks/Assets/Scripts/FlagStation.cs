using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagStation : MonoBehaviour
{
    // Numer bazy / stacji
    public int flagStationNumber;

    private void OnTriggerEnter(Collider other)
    {
        Vehicle vehicleScript = other.gameObject.GetComponentInParent<Vehicle>();
        if (vehicleScript == null) return;

        // Jeżeli numer player'a jest taki sam jak numer bazy (czyli czy gracz jest w swojej bazie)
        if (vehicleScript.playerNumber == flagStationNumber)
        {
            // Jeżeli gracz posiada jakąś flagę
            if (other.GetComponentInParent<PlayerFlagManager>().CheckFlag() == true)
            {
                other.GetComponentInParent<PlayerFlagManager>().DropFlag();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<FlagManager>().DecreaseLeftFlagNumber(vehicleScript.playerNumber);
            }
        }
    }
}
