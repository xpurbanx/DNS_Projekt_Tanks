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
        flag.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
        flag.GetComponent<Flag>().isTaken = true;
        return flag;
    }

    public void flagDestroy()
    {
        Destroy(flag);
    }
}
