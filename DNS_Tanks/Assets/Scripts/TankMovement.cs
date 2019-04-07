using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Tooltip("Numer gracza. Przykład: gracz 1 będzie kierował klawiszami z dopiskiem 1 (sprawdź Project Settings -> Input)")]
    public int playerNumber = 1;
    [Tooltip("Prędkość poruszania się pojazdu")]
    public float speed = 925f;
    [Tooltip("Prędkość skręcania pojazdu")]
    public float turnSpeed = 180f;
    [Tooltip("Maksymalna prędkość, którą może osiągnąć pojazd")]
    public float maxVelocity = 3f;

    private string movementAxisName;
    private string turnAxisName;
    private Rigidbody rigidbody;
    private float movementInputValue;
    private float turnInputValue;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Po włączeniu skryptu upewniamy się, że na czołg mogą działać siły i zerujemy aktualnie działające siły
    private void OnEnable()
    {
        rigidbody.isKinematic = false;
        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    void Start()
    {
        // Ustanawianie konkretnych nazw inputów dla danego czołgu. 
        movementAxisName = "Vertical" + playerNumber;
        turnAxisName = "Horizontal" + playerNumber;

    }

    void Update()
    {
        // Input gracza
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
    }

    private void FixedUpdate()
    {
        // Poruszanie się czołgu, jechanie prosto do tyłu i skręcanie
        Move();
        Turn();

        // Maksymalna prędkość pojazdu
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVelocity);
    }

    private void Move()
    {
        // Poruszanie się prosto (lub do tyłu, zależy od movementInputValue) z określoną prędkością
        Vector3 movement = transform.forward * movementInputValue * speed * Time.deltaTime;
        
        // Poruszanie obiektem jest oparte na dodawaniu siły
        rigidbody.AddForce(movement);
    }

    private void Turn()
    {
        // Stopień skręcania
        float turn = turnInputValue * turnSpeed * Time.deltaTime;

        // Unity wymyśliło sobie taki powalony typ jak Quaternion, ale nie wolno się bać
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
        return;
    }
}
