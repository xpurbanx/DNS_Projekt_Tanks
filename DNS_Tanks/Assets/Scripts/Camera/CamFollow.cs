using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private CurrentVehicle currentVeh;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrentVeh();
        player = currentVeh.CurrentVehicleTransform().gameObject;
        offset = transform.position - player.transform.position;
    }

    public void UpdateCurrentVeh()
    {
        currentVeh = GetComponentInParent<CurrentVehicle>();
    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(player != null)
            transform.position = player.transform.position + offset;
    }
}
