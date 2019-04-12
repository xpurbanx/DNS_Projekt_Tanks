using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagStation : MonoBehaviour
{
    // Czy flaga została dostarczona?
    [HideInInspector]
    public bool flagInsterted = false;
    // Numer bazy, stacji
    private string flagStationNumber = "";
    // Czy gra się zakończyła?
    private bool gameEnded = false;

    void Start()
    {
        // Numer stacji z jej tagu
        flagStationNumber = gameObject.tag.Substring(gameObject.name.Length - 1);
    }

    void Update()
    {
        // Jeżeli gra się nie skończyła
        if (gameEnded == false)
            // Jeżeli flaga została dostarczona
            if (flagInsterted == true)
                // Wygrana
                Win();
    }

    private void OnTriggerEnter(Collider other)
    {
        string shortTag = other.gameObject.tag.Substring(0, 6);
        // Jeżeli obiekt, który koliduje z bazą posiada tag Player
        if (shortTag == "Player")
        {
            // Pobieramy numer gracza za pomocą tagu (ostatnia cyfra)
            string playerNumber = other.tag.Substring(other.tag.Length - 1);

            // Jeżeli numer player'a jest taki sam jak numer bazy (czyli czy gracz jest w swojej bazie
            if (playerNumber == flagStationNumber)
            {
                // Pobieramy gameobject Tank tego gracza, dość brzydko bo za pomocą Gameobject Find, ale nie mogłem wpaść na inny pomysł
                GameObject player = GameObject.Find("Tank " + playerNumber);

                // Jeżeli gracz posiada jakąś flagę
                if (player.GetComponent<PlayerEquipment>().holdingFlag == true)
                {
                    // Flaga została dostarczona
                    flagInsterted = true;
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

        gameEnded = true;
    }
}
