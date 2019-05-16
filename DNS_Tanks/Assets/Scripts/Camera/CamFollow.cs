using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float rotationSpeed = 20f;
    private CurrentVehicle currentVeh;
    private PlayerInputSetup playerInput;
    bool offsetSet = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
        UpdateCurrentVeh();
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    public void UpdateCurrentVeh()
    {
        
        currentVeh = GetComponentInParent<CurrentVehicle>();
        player = currentVeh.CurrentVehicleTransform().gameObject;
        if(!offsetSet)
        {
            offset = transform.position - player.transform.position;
            offsetSet = true;
            transform.LookAt(player.transform);
        }

    }

    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(player != null)
            transform.position = player.transform.position + offset;


        RotateCamera();
    }

    private void RotateCamera()
    {

        //transform.position = player.transform.position + offset;

         if (playerInput.RightAnalogButton())
         {
            float rotationOffset = (transform.transform.eulerAngles.y - player.transform.eulerAngles.y);
            if (Mathf.Abs(rotationOffset) > 2)
            {        //transform.RotateAround(player.transform.position, transform.right * playerInput.SecondaryHorizontal() * rotationSpeed * Time.deltaTime);

                Vector3 direction = Vector3.up; //clockwise
                if (rotationOffset < 0 && rotationOffset > -180 || rotationOffset > 180 && rotationOffset < 360)
                    direction = Vector3.up;   //clockwise
                else
                    direction = Vector3.down; //counter clockwise
                transform.RotateAround(player.transform.position, direction, rotationSpeed * Time.deltaTime);
                    offset = (transform.position - player.transform.position);
                    transform.LookAt(player.transform);
            }

        }
        
    }
}
