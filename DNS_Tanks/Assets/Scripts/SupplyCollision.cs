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
        //Instantiate(chSupply, pos, supp.transform.rotation);
    }

    public void OnTriggerExit(Collider other)
    {
            colliding = false;
        //  Instantiate(chSupply, pos, supp.transform.rotation);
        // do naprawy
    }
}
