using UnityEngine;

public class PlayerFlagManager : MonoBehaviour
{
    // Czy czołg trzyma flagę
    private bool holdingFlag = false;
    private FlagCarrier flagCarrier;
    private GameObject flagObject;

    private void OnEnable()
    {
        flagCarrier = gameObject.GetComponentInChildren<FlagCarrier>(true);
    }

    // Wprowadzam troche hermetyzacji.
    public void PickFlag()
    {
        holdingFlag = true;
        flagObject = flagCarrier.flagMake();
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

    public void DropFlagAfterDeath(Vector3 position)
    {
        if (holdingFlag)
        {
            GameObject flag = Instantiate(flagObject, position + new Vector3(0, 0.3f, 0), Quaternion.identity);
            flag.GetComponent<Flag>().isTaken = false;
            holdingFlag = false;
            flag.GetComponent<Flag>().Enable();
        }
    }
}
