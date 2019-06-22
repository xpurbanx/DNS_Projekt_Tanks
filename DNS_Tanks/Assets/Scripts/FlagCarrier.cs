using System.Runtime.CompilerServices;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]

public class FlagCarrier : MonoBehaviour
{
    public GameObject flagPrefab;
    internal GameObject flag;

    public GameObject flagMake()
    {
        flag = Instantiate(flagPrefab, transform.position, transform.rotation, transform);
        flag.GetComponent<Flag>().isTaken = true;
        return flag;
    }

    public void flagDestroy()
    {
        Debug.Log("NISZCZENIE FLAGI");
        Destroy(flag);
    }
}
