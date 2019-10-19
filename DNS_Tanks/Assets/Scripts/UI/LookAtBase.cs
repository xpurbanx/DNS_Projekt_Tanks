using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBase : MonoBehaviour
{
    public int playerNumber;

    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("FlagStation " + playerNumber).transform);
        //transform.GetChild(1).LookAt(GameObject.FindGameObjectWithTag("Camera " + playerNumber).transform);
    }
}
