using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagStation : MonoBehaviour
{
    // Czy flaga została dostarczona?
    [HideInInspector]
    public bool flagInsterted = false;

    // Numer bazy / stacji
    public int flagStationNumber;

    private void OnTriggerEnter(Collider other)
    {
        // Pierwsze 7 znaków tagu. Np. z Player 1 będzie to Player
        if (other.gameObject.tag.Length < 7) return;
        string shortTag = other.gameObject.tag.Substring(0, 7);

        // Jeżeli obiekt, który koliduje z bazą posiada tag Player
        if (shortTag == "Player ")
        {
            // Pobieramy numer gracza za pomocą tagu (ostatnia cyfra)
            string playerNumberString = other.tag.Substring(other.tag.Length - 1);
            int playerNumber = Utility.ParseToInt(playerNumberString);

            // Jeżeli numer player'a jest taki sam jak numer bazy (czyli czy gracz jest w swojej bazie
            if (playerNumber == flagStationNumber)
            {
                // Pobieramy gameobject Tank tego gracza, dość brzydko bo za pomocą Gameobject Find, ale nie mogłem wpaść na inny pomysł
                GameObject player = GameObject.Find("Vehicle " + playerNumberString);

                // Jeżeli gracz posiada jakąś flagę
                if (player.GetComponent<PlayerFlagManager>().CheckFlag() == true)
                {
                    player.GetComponent<PlayerFlagManager>().DropFlag();
                    // Flaga została dostarczona
                    flagInsterted = true;
                    Win();
                }
            }
        }
    }

    private void Win()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("WIN");
        }
    }
}
