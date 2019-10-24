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


    [SerializeField]
    bool classicCam = false;
    [SerializeField]
    Vector3 classicOffset;

    int left, right;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateFunction(player.transform.GetChild(0).position, 3f));
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
        int angle;
        float frontOffset;
        if (autoRotate)
        {
            rotationSpeed = defaultRotationSpeed;
            angle = angleDefault; // powyzej tej wartosci zaczyna obracac do srodka
        }
        else
        {
            rotationSpeed = 0;
            angle = 2; // wtedy jest na srodku, 

        }

        if (playerInput.RightAnalogButton())
        {
            rotationSpeed = 100f; // gotta go fast
            angle = 2; // wtedy jest na srodku
        }

        frontOffset = player.transform.eulerAngles.y - transform.transform.eulerAngles.y;
        if ((Mathf.Abs(frontOffset) > angle) && (playerInput.RightAnalogButton() || autoRotate))
        {
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
            if (Mathf.Abs(frontOffset) < angle)
            {
                startedRotating = false;
            }

        }
    }

    IEnumerator RotateFunction(/*GameObject poll,*/ Vector3 pivotPos, float degree)
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime * 0.1f;
            transform.RotateAround(pivotPos, new Vector3(0, 1, 0), degree * Time.deltaTime);
            Debug.Log("PLAYER: " + player.transform.position + " | CAMERA: " + transform.position);
            // If the object has arrived, stop the coroutine
            if (timeSinceStarted >= 1f)
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    private void RotateTurretFront()
    {
        int left, right;
        if (autoRotate)
        {
            rotationSpeed = defaultRotationSpeed;
            left = leftDefault; // daje margines bledu
            right = rightDefault;
        }
        else
        {
            rotationSpeed = 0;
            left = 184; // wtedy jest na srodku
            right = 176;
        }
        if (playerInput.RightAnalogButton())
        {
            rotationSpeed = 100f; // gotta go fast
            left = 184; // wtedy jest na srodku
            right = 176;
        }
        //dla czolgu dziala, mozna zrobic jakies ladniejsze rozwiazanie
        float frontOffset = turret.transform.localEulerAngles.y + player.transform.rotation.eulerAngles.y - transform.eulerAngles.y + 180; // 180 bo tak jest w TankRotation (chyba dlatego)
        frontOffset = frontOffset % 360;// zeby nie wychodzilo za 360
        if ((!(Mathf.Abs(frontOffset) < left && Mathf.Abs(frontOffset) > right)) && (playerInput.RightAnalogButton() || autoRotate))
        {
            // Debug.Log("TURRET: " + turret.transform.localEulerAngles.z + "   CAMERA: " + transform.eulerAngles.y + "  offset: " + frontOffset);
            startedRotating = true;
        }


        if (startedRotating)
        {
            Vector3 direction = Vector3.up; //clockwise
            if (frontOffset < 0 && frontOffset > -180 || frontOffset > 180 && frontOffset < 360) // okresla w ktora strone sie obraca
                direction = Vector3.up;   //clockwise
            else
                direction = Vector3.down; //counter clockwise
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            transform.RotateAround(playerPos, direction, rotationSpeed * Time.deltaTime);
            offset = transform.position - player.transform.position;
            //transform.LookAt(player.transform);
            if ((Mathf.Abs(frontOffset) < left && Mathf.Abs(frontOffset) > right))
            {
                startedRotating = false;
            }

        }

    }
}
