using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSwitch : MonoBehaviour
{
    public int playerNumber = 0;
    private Vector3 center = Vector3.zero;
    public float radius = 0.5f;

    void Start()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;
        center = transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (other.transform.parent.tag == "Player " + playerNumber)
                Debug.Log("Można wyświetlić panel!");
        }
    }

    void Update()
    {
        SphereCollider c = gameObject.GetComponent<SphereCollider>();
        c.radius = radius;
    }
}
