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
        if (other.GetComponentInChildren<BaseCheck>() == null)
            colliding = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInChildren<BaseCheck>() == null)
            colliding = false;
    }
}
