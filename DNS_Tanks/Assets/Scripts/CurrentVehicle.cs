using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentVehicle : MonoBehaviour
{
    public GameObject currentVeh;

    // Pozwoli na łatwiejszą zmianę pojazdow, kamera bedzie automatycznie podazac za pojazdem wskazanym przez currentVeh
    void Start()
    {
        UpdateCurrentVeh();
    }

    public void UpdateCurrentVeh()
    {
        currentVeh = transform.GetChild(0).gameObject; // za currentVeh bierze obiekt na samej gorze hierarhii (index 0)
        currentVeh.GetComponentInParent<PlayerFlagManager>().UpdateAfterDeath();
    }

    public Transform CurrentVehicleTransform()
    {
        return currentVeh.transform;
    }
}
