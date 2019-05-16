using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsGrounded : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain" && gameObject.name == "Collider1")
        {
            GetComponentInParent<PlayerMovement>().touchingGroundOne = true;
        }

        if (other.gameObject.tag == "Terrain" && gameObject.name == "Collider2")
        {
            GetComponentInParent<PlayerMovement>().touchingGroundTwo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Terrain" && gameObject.name == "Collider1")
        {
            GetComponentInParent<PlayerMovement>().touchingGroundOne = false;
        }

        if (other.gameObject.tag == "Terrain" && gameObject.name == "Collider2")
        {
            GetComponentInParent<PlayerMovement>().touchingGroundTwo = false;
        }
    }
}
