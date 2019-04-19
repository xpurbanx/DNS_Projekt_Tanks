using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCarrier : MonoBehaviour
{
    public GameObject flagPrefab;
    GameObject flag;

    public void flagMake()
    {
        flag = Instantiate(flagPrefab, transform.position, transform.rotation, transform);

    }

    public void flagDestroy()
    {
        Debug.Log("NISZCZENIE FLAGI");
        Destroy(flag);
    }
}
