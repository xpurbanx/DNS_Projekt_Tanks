using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]

public class PlayerRotateTurret : MonoBehaviour
{
    public GameObject turret;
    internal float turnTurretSpeed = 20f;

    private PlayerInputSetup playerInput;
    private float turnTurretInputValue;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
        if (playerInput == null)
            Debug.Log("BRAK PLAYERINPUT DLA PlayerRotateTurret");
       // turret = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        turnTurretInputValue = playerInput.SecondaryHorizontal();
    }

    private void FixedUpdate()
    {
        // Poruszanie się czołgu, jechanie prosto do tyłu i skręcanie
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
        Vector3 rotation = new Vector3 (0f, 0f, turnTurret);
        //turret.MoveRotation(rigidbody.rotation * turnRotation);
        transform.Rotate(rotation);
        return;
    }
}
