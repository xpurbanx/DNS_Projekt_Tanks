using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject turret;
    [SerializeField]
    private float defaultRotationSpeed = 10f;
    private float rotationSpeed = 25f;
    private CurrentVehicle currentVeh;
    private PlayerInputSetup playerInput;
    bool offsetSet = false;
    private Vector3 offset;
    [SerializeField]
    int cameraOffset = 10;
    [SerializeField]
    bool autoRotate = true;
    [SerializeField]
    bool followTurret = true;
    float frontOffset;
    bool startedRotating = false;
    [SerializeField]
    [Tooltip("followTurret max angle left on autoRotate")]
    int leftDefault = 220;
    [SerializeField]
    [Tooltip("followTurret max angle right on autoRotate")]
    int rightDefault = 168;
    [SerializeField]
    [Tooltip("followBody max angle (when turning towards body, !followTurret) on autoRotate")]
    int angleDefault = 20;
    float t = 0f;

    private float leftCenter = 180;  // 184 - wartosc "srodka" z lewej strony
    private float rightCenter = 170; // 176 - wartosc "srodka" z prawej strony
                                     // chodzi o to, ze kamera centruje sie do tego przedzialu stopni

    [SerializeField]
    bool classicCam = false;
    [SerializeField]
    Vector3 classicOffset;

    int left, right;
    void Start()
    {
        //StartCoroutine(RotateFunction(player.transform.position, 45f));
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

            if (classicCam)
            {
                // transform.rotation.SetEulerAngles(66, transform.rotation.y, transform.rotation.z);
                transform.Translate(classicOffset);
                transform.LookAt(player.transform);
            }
            offset = transform.position - player.transform.position;
            offsetSet = true;

        }

    }

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    void LateUpdate() // LATE!
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player != null)
        {
            transform.position = player.transform.position + offset;
            if (Lock().aimingLocked == false && Lock().allLocked == false)
                RotateCamera();
        }
    }

    private void RotateCamera()
    {
        if (followTurret)
        {
            RotateTurretFront();
        }
        else
        {
            RotateBodyFront();
        }


    }
    private void RotateBodyFront()
    {
        t += 0.001f;
        int angle;
        float frontOffset;
        if (autoRotate)
        {
            rotationSpeed = Mathf.Lerp(0f, defaultRotationSpeed, t) * 10f;//rotationSpeed = defaultRotationSpeed;
            //rotationSpeed = defaultRotationSpeed;
            angle = angleDefault; // powyzej tej wartosci zaczyna obracac do srodka
        }
        else
        {
            rotationSpeed = 0;
            angle = angleDefault; // wtedy jest na srodku, 

        }

        if (playerInput.RightAnalogButton())
        {
            rotationSpeed = 100f; // gotta go fast
            angle = angleDefault; // wtedy jest na srodku
        }

        frontOffset = player.transform.eulerAngles.y - transform.transform.eulerAngles.y;
        if ((Mathf.Abs(frontOffset) > angle) && (playerInput.RightAnalogButton() || autoRotate))
        {
            Debug.Log("Autorotate: " + autoRotate + "   frontOffset: " + frontOffset);
            startedRotating = true;
        }


        if (startedRotating)
        {
            Vector3 direction = Vector3.down; //clockwise
            if (frontOffset < 0 && frontOffset > -180 || frontOffset > 180 && frontOffset < 360)// okresla w ktora strone sie obraca
                direction = Vector3.down;   //clockwise
            else
                direction = Vector3.up; //counter clockwise
            transform.RotateAround(player.transform.position, direction, rotationSpeed * Time.deltaTime);
            offset = transform.position - player.transform.position;
            //transform.LookAt(player.transform);
            if (Mathf.Abs(frontOffset) < 2) // 2 stopnie bledu wzgledem srodka
            {
                startedRotating = false;
                t = 0;
            }

        }
    }

    private void RotateTurretFront()
    {
        t += 0.001f;
        int turretAngle;
        float frontOffset;
        if (autoRotate)
        {
            rotationSpeed = Mathf.Lerp(0.8f, defaultRotationSpeed, t) * 25f;//rotationSpeed = defaultRotationSpeed;
            //rotationSpeed = defaultRotationSpeed;
            turretAngle = angleDefault; // powyzej tej wartosci zaczyna obracac do srodka
        }
        else
        {
            rotationSpeed = 0;
            turretAngle = angleDefault; // wtedy jest na srodku, 

        }

        if (playerInput.RightAnalogButton())
        {
            rotationSpeed = Mathf.Lerp(3f, defaultRotationSpeed*3.5f, t) * 25f;//rotationSpeed = defaultRotationSpeed;//rotationSpeed = 100f; // gotta go fast
            turretAngle = angleDefault; // wtedy jest na srodku
        }

        frontOffset = player.GetComponentInChildren<PlayerRotateTurret>().transform.eulerAngles.y - transform.transform.eulerAngles.y;
        if ((Mathf.Abs(frontOffset) > turretAngle) && (playerInput.RightAnalogButton() || autoRotate))
        {
            Debug.Log("Autorotate: " + autoRotate + "   frontOffset: " + frontOffset);
            startedRotating = true;
        }


        if (startedRotating)
        {
            Vector3 direction = Vector3.down; //clockwise
            if (frontOffset < 0 && frontOffset > -180 || frontOffset > 180 && frontOffset < 360)// okresla w ktora strone sie obraca
                direction = Vector3.down;   //clockwise
            else
                direction = Vector3.up; //counter clockwise
            transform.RotateAround(player.transform.position, direction, rotationSpeed * Time.deltaTime);
            offset = transform.position - player.transform.position;
            //transform.LookAt(player.transform);
            if (Mathf.Abs(frontOffset) < 2) // 2 stopnie bledu wzgledem srodka
            {
                startedRotating = false;
                t = 0;
            }

        }
    }
}
