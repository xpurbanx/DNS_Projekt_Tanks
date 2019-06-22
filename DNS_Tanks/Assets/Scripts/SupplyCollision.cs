using System.Collections;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]

public class SupplyCollision : MonoBehaviour
{
    internal bool colliding;

    public void OnTriggerStay(Collider other)
    {
        colliding = true;
    }

    public void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}
