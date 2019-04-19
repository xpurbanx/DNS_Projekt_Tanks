using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateTurret : MonoBehaviour
{
    public GameObject turret;
    [HideInInspector]
    public float turnTurretSpeed;

    private PlayerInputSetup playerInput;
    private float turnTurretInputValue;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInputSetup>();
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
        float turnTurret = turnTurretInputValue * turnTurretSpeed * Time.deltaTime;

        // Unity wymyśliło sobie taki powalony typ jak Quaternion, ale nie wolno się bać
        //Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        //Quaternion turnRotation = Quaternion.Euler(-90f, 0f, turnTurret);
        Vector3 rotation = new Vector3 (0f, 0f, turnTurret);
        //turret.MoveRotation(rigidbody.rotation * turnRotation);
        turret.transform.Rotate(rotation);
        return;
    }
}
