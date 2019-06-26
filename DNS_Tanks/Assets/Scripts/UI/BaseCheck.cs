using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCheck : MonoBehaviour
{
    public int playerNumber;

    private void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player " + playerNumber + " Spawn").transform.position;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player " + playerNumber)
        {
            GameObject.FindGameObjectWithTag("Base " + playerNumber).GetComponentInChildren<Light>().enabled = false;

            MeshRenderer[] mesh = GameObject.FindGameObjectWithTag("Base " + playerNumber).GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i <= mesh.Length - 1; i++)
            {
                mesh[i].enabled = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player " + playerNumber)
        {
            GameObject.FindGameObjectWithTag("Base " + playerNumber).GetComponentInChildren<Light>().enabled = true;

            MeshRenderer[] mesh = GameObject.FindGameObjectWithTag("Base " + playerNumber).GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i <= mesh.Length - 1; i++)
            {
                mesh[i].enabled = true;
            }
        }
    }
}
