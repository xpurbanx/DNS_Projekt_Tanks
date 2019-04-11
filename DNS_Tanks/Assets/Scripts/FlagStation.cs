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
        // Numer stacji jest znany dzięki dwóm ostatnim cyfrom na końcu nazwy obiektu
        flagStationNumber = gameObject.name.Substring(gameObject.name.Length - 2);
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
        // Jeżeli obiekt, który koliduje z bazą posiada tag Player
        if (other.tag == "Player")
        {
            // Pobieramy numer tego player'a, za pomocą dwóch ostatnich cyfr nazwy jego obiektu
            string tankNumber = other.name.Substring(other.name.Length - 2);

            // Jeżeli numer player'a jest taki sam jak numer bazy (czyli czy gracz jest w swojej bazie
            if (tankNumber == flagStationNumber)
            {
                // Jeżeli gracz posiada jakąś flagę
                if (other.GetComponent<PlayerEquipment>().holdingFlag == true)
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
