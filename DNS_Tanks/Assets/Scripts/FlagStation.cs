using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagStation : MonoBehaviour
{
    [HideInInspector]
    public bool flagInsterted = false;
    private string flagStationNumber = "";
    private bool gameEnded = false;

    void Start()
    {
        flagStationNumber = gameObject.name.Substring(gameObject.name.Length - 2);
    }

    void Update()
    {
        if (gameEnded == false)
            if (flagInsterted == true)
                Win();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            string tankNumber = other.name.Substring(other.name.Length - 2);

            if (tankNumber == flagStationNumber)
            {
                if (other.GetComponent<PlayerEquipment>().holdingFlag == true)
                {
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
