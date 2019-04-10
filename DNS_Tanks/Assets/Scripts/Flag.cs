using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private string flagNumber = "";

    void Start()
    {
        flagNumber = gameObject.name.Substring(gameObject.name.Length - 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            string playerNumber = other.gameObject.name.Substring(gameObject.name.Length - 2);

            if (flagNumber != playerNumber)
            {
                PickUpFlag(other.gameObject);
            }
        }
    }

    private void PickUpFlag(GameObject tank)
    {
        tank.GetComponent<PlayerEquipment>().holdingFlag = true;
        gameObject.SetActive(false);
    }
}
