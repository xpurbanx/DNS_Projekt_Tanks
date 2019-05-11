using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject turret;
    [SerializeField]
    private float rotationSpeed = 20f;
    private CurrentVehicle currentVeh;
    private PlayerInputSetup playerInput;
    bool offsetSet = false;
    private Vector3 offset;
    bool thirdPerson = true;
    float turretFrontOffset;
    bool startedRotating = false;
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
        turret = currentVeh.CurrentVehicleTransform().gameObject.GetComponentInChildren<PlayerRotateTurret>().gameObject;
        if (turret == null)
            Debug.Log("Turret in CamFollow == null");
        Debug.Log(turret);
        if (!offsetSet)
        {
            offset = transform.position - player.transform.position;
            offsetSet = true;
            transform.LookAt(player.transform);
        }

    }

    void FixedUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player != null)
            transform.position = player.transform.position + offset;


        RotateCamera();
    }

    private void RotateCamera()
    {

        //transform.position = player.transform.position + offset;

        if (playerInput.RightAnalogButton() && !thirdPerson)
        {
            float vehFrontOffset = transform.transform.eulerAngles.y - player.transform.eulerAngles.y;
            if (Mathf.Abs(vehFrontOffset) > 2)
            {        //transform.RotateAround(player.transform.position, transform.right * playerInput.SecondaryHorizontal() * rotationSpeed * Time.deltaTime);

                Vector3 direction = Vector3.up; //clockwise
                if (vehFrontOffset < 0 && vehFrontOffset > -180 || vehFrontOffset > 180 && vehFrontOffset < 360)
                    direction = Vector3.up;   //clockwise
                else
                    direction = Vector3.down; //counter clockwise
                transform.RotateAround(player.transform.position, direction, rotationSpeed * Time.deltaTime);
                offset = transform.position - player.transform.position;
                transform.LookAt(player.transform);
            }

        }
        rotationSpeed = 30f;
        if (thirdPerson)
        {
            if (playerInput.RightAnalogButton())
                rotationSpeed = 200f;

            //Debug.Log("Rotate to turret");

            float turretFrontOffset = turret.transform.eulerAngles.y - transform.transform.eulerAngles.y;
            //Debug.Log("turret rotation relative to body:  " + turret.transform.eulerAngles.y + "   Body rotation " + transform.eulerAngles.y + "   turretOffset " + turretFrontOffset);
            if (Mathf.Abs(turretFrontOffset) > 220 || Mathf.Abs(turretFrontOffset) < 160)
            {        //transform.RotateAround(player.transform.position, transform.right * playerInput.SecondaryHorizontal() * rotationSpeed * Time.deltaTime);
                turretFrontOffset = turretFrontOffset * -1;
                Vector3 direction = Vector3.down; //clockwise
                if (turretFrontOffset < 0 && turretFrontOffset > -180 || turretFrontOffset > 180 && turretFrontOffset < 360)

                    direction = Vector3.down;   //clockwise
                else
                    direction = Vector3.up; //counter clockwise
                transform.RotateAround(player.transform.position, direction, rotationSpeed * Time.deltaTime);
                offset = transform.position - player.transform.position;
                transform.LookAt(player.transform);
            }

        }

    }
}
        /*if (thirdPerson)
        {
            if(playerInput.RightAnalogButton())
                rotationSpeed = 200f;

            //Debug.Log("Rotate to turret");

            float turretFrontOffset = turret.transform.eulerAngles.y - transform.transform.eulerAngles.y;
            //Debug.Log("turret rotation relative to body:  " + turret.transform.eulerAngles.y + "   Body rotation " + transform.eulerAngles.y + "   turretOffset " + turretFrontOffset);
            if (Mathf.Abs(turretFrontOffset) > 220 || Mathf.Abs(turretFrontOffset) < 160)
            {        //transform.RotateAround(player.transform.position, transform.right * playerInput.SecondaryHorizontal() * rotationSpeed * Time.deltaTime);
                turretFrontOffset = turretFrontOffset* -1;
                Vector3 direction = Vector3.down; //clockwise
                if (turretFrontOffset< 0 && turretFrontOffset> -180 || turretFrontOffset > 180 && turretFrontOffset< 360)

                  direction = Vector3.down;   //clockwise
                else
                    direction = Vector3.up; //counter clockwise
                transform.RotateAround(player.transform.position, direction, rotationSpeed* Time.deltaTime);
                offset = transform.position - player.transform.position;
                transform.LookAt(player.transform);
            }
        }*/