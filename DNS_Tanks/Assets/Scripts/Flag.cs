using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    // Numer flagi
    // private string flagNumber = "";
    private string flagNumber;

    void Start()
    {
        // Numer flagi jest znany dzięki dwóm ostatnim cyfrom na końcu nazwy obiektu
        flagNumber = gameObject.name.Substring(gameObject.name.Length - 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Jeżeli z flagą koliduje obiekt o tagu Player
        if (other.gameObject.tag == "Player")
        {
            // Pobieramy numer tanka, są to dwie ostetnie cyfry nazwy jego obiektu
            string playerNumber = other.gameObject.name.Substring(gameObject.name.Length - 2);

            // Jeżeli czołg, z którym kolidujemy nie jest właścicielem tej flagi (czołg nie może nieść swojej flagi)***
            // I jeżeli czołg, z którym kolidujemy nie posiada już flagi (nie może przecież nieść dwóch na raz)
            // ***Możemy to jeszcze zmienić
            if (flagNumber != playerNumber && other.GetComponent<PlayerEquipment>().holdingFlag == false)
            {
                // Czołg bierze flagę
                PickUpFlag(other.gameObject);
            }
        }
    }

    private void PickUpFlag(GameObject tank)
    {
        // Zmieniamy w Eq czołgu, że nosi on aktualnie flagę
        tank.GetComponent<PlayerEquipment>().holdingFlag = true;
        // gameObject flagi ustawiamy na nieaktywny, przez co wszystkie skrypty, collidery i mesh zostają wyłączone
        // Dla podkreślenia: SKRYPTY TEŻ PRZESTAJĄ DZIAŁAĆ
        gameObject.SetActive(false);
    }
}
