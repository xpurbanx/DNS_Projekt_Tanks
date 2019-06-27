using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCheck : MonoBehaviour
{
    public int playerNumber;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player " + playerNumber)
        {
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
            MeshRenderer[] mesh = GameObject.FindGameObjectWithTag("Base " + playerNumber).GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i <= mesh.Length - 1; i++)
            {
                mesh[i].enabled = true;
            }
        }
    }
}
