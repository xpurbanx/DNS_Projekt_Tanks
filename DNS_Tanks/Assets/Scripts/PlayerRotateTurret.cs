using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]

public class PlayerRotateTurret : MonoBehaviour
{
    public GameObject turret;
    private Vehicle vehicle;
    internal float turnTurretSpeed = 20f;

    private PlayerInputSetup playerInput;
    private float turnTurretInputValue;

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    void Start()
    {
        turnTurretSpeed = GetComponentInParent<Vehicle>().turnTurretSpeed;
        playerInput = GetComponentInParent<PlayerInputSetup>();
        if (playerInput == null)
            Debug.Log("BRAK PLAYERINPUT DLA PlayerRotateTurret");
        // turret = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (playerInput.LeftBumper())
            turnTurretInputValue -= 0.1f;
        else if (playerInput.RightBumper())
            turnTurretInputValue += 0.1f;
        else
            turnTurretInputValue = playerInput.SecondaryHorizontal();


    }

    private void FixedUpdate()
    {
        // Poruszanie się czołgu, jechanie prosto do tyłu i skręcanie
        if (Lock().aimingLocked == false && Lock().allLocked == false)
            TurnTurret();
    }


    private void TurnTurret()
    {

        // Stopień skręcania
        float turnTurret = turnTurretInputValue * turnTurretSpeed * Time.deltaTime * 5f;
        // Debug.Log("TURNING  " + turnTurretInputValue);
        // Unity wymyśliło sobie taki powalony typ jak Quaternion, ale nie wolno się bać
        //Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        //Quaternion turnRotation = Quaternion.Euler(-90f, 0f, turnTurret); 
        Vector3 rotation = new Vector3 (0f, turnTurret, 0f );
        //turret.MoveRotation(rigidbody.rotation * turnRotation);
        transform.Rotate(rotation);
        return;
    }
}
