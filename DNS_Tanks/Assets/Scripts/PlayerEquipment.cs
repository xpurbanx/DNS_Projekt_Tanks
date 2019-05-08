using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    // Czy czołg trzyma flagę
    [HideInInspector]
    private bool holdingFlag = false;
    private FlagCarrier flagCarrier;

    private void Start()
    {
        flagCarrier = gameObject.GetComponentInChildren<FlagCarrier>(true);
        Debug.Log(flagCarrier);
    }

    // Wprowadzam troche hermetyzacji.
    public void pickFlag()
    {
        holdingFlag = true;
        flagCarrier.flagMake();
    }

    public void dropFlag()
    {
        holdingFlag = false;
        flagCarrier.flagDestroy();
    }

    public bool checkFlag()
    {
        return holdingFlag;
    }
}
