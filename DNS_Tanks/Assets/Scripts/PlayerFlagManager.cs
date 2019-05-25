using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlagManager : MonoBehaviour
{
    // Czy czołg trzyma flagę
    [HideInInspector]
    private bool holdingFlag = false;
    private FlagCarrier flagCarrier;

    private void Start()
    {
        flagCarrier = gameObject.GetComponentInChildren<FlagCarrier>(true);
    }

    // Wprowadzam troche hermetyzacji.
    public void PickFlag()
    {
        holdingFlag = true;
        flagCarrier.flagMake();
    }

    public void DropFlag()
    {
        holdingFlag = false;
        flagCarrier.flagDestroy();
    }

    public bool CheckFlag()
    {
        return holdingFlag;
    }

    public void UpdateAfterDeath()
    {
        flagCarrier = gameObject.GetComponentInChildren<FlagCarrier>(true);
    }
}
