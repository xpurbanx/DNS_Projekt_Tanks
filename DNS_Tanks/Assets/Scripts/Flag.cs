using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [Header("Numer flagi, odpowiada numerowi gracza, do którego należy flaga:")]
    public int flagNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Pierwsze 7 znaków tagu. Np. z Player 1 będzie to Player
        if (other.gameObject.tag.Length < 7) return;
        string shortTag = other.gameObject.tag.Substring(0, 7);

        // Jeżeli z flagą koliduje obiekt o tagu Player (...)
        if (shortTag == "Player ")
        {
            // Pobieramy numer gracza za pomocą tagu (ostatnia cyfra)
            // Pobieramy gameobject Tank tego gracza, dość brzydko bo za pomocą GameObject Find, ale nie mogłem wpaść na inny pomysł
            string playerNumberString = other.gameObject.tag.Substring(other.gameObject.tag.Length - 1);
            int playerNumber = Utility.ParseToInt(playerNumberString);

            GameObject player = GameObject.Find("Tank " + playerNumberString);

            // Jeżeli czołg, z którym kolidujemy nie jest właścicielem tej flagi (czołg nie może nieść swojej flagi)*
            // I jeżeli czołg, z którym kolidujemy nie posiada już flagi (nie może przecież nieść dwóch na raz)
            // *Możemy to jeszcze zmienić
            if (flagNumber != playerNumber && player.GetComponent<PlayerEquipment>().checkFlag() == false)
            {
                // Czołg bierze flagę
                PickUpFlag(player);
            }
        }
    }

    private void PickUpFlag(GameObject player)
    {
        // Zaznaczamy w Eq czołgu, że nosi on aktualnie flagę
        player.GetComponent<PlayerEquipment>().pickFlag();

        // gameObject flagi ustawiamy na nieaktywny, przez co wszystkie skrypty, collidery i mesh zostają wyłączone
        // Dla podkreślenia: SKRYPTY TEŻ PRZESTAJĄ DZIAŁAĆ, a sam obiekt nie zmienia swojej pozycji
        gameObject.SetActive(false);
    }
}
