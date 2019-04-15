using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    // Numer flagi
    private string flagNumberString;
    private int flagNumber;

    void Start()
    {
        // Numer flagi z jej tagu
        flagNumberString = gameObject.tag.Substring(gameObject.tag.Length - 1);
        flagNumber = Utility.ParseToInt(flagNumberString);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Pierwsze 7 znaków tagu. Np. z Player 1 będzie to Player
        string shortTag = other.gameObject.tag.Substring(0, 7);

        // Jeżeli z flagą koliduje obiekt o tagu Player (...)
        if (shortTag == "Player ")
        {
            // Pobieramy numer gracza za pomocą tagu (ostatnia cyfra)
            // Pobieramy gameobject Tank tego gracza, dość brzydko bo za pomocą Gameobject Find, ale nie mogłem wpaść na inny pomysł
            string playerNumberString = other.gameObject.tag.Substring(other.gameObject.tag.Length - 1);
            int playerNumber = Utility.ParseToInt(playerNumberString);

            GameObject player = GameObject.Find("Tank " + playerNumberString);

            // Jeżeli czołg, z którym kolidujemy nie jest właścicielem tej flagi (czołg nie może nieść swojej flagi)*
            // I jeżeli czołg, z którym kolidujemy nie posiada już flagi (nie może przecież nieść dwóch na raz)
            // *Możemy to jeszcze zmienić
            if (flagNumber != playerNumber && player.GetComponent<PlayerEquipment>().holdingFlag == false)
            {
                // Czołg bierze flagę
                PickUpFlag(player);
            }
        }
    }

    private void PickUpFlag(GameObject player)
    {
        // Zmieniamy w Eq czołgu, że nosi on aktualnie flagę
        player.GetComponent<PlayerEquipment>().holdingFlag = true;

        // gameObject flagi ustawiamy na nieaktywny, przez co wszystkie skrypty, collidery i mesh zostają wyłączone
        // Dla podkreślenia: SKRYPTY TEŻ PRZESTAJĄ DZIAŁAĆ
        gameObject.SetActive(false);
    }
}
