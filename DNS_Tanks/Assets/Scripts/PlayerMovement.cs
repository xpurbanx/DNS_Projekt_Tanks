using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Na sposób poruszania ma też wpływ samo Rigibody, jego parametry można zmienić w Unity, w inspektorze
    // Czyli: Drag - tarcie, po jakim czasie od puszczenia przycisków pojazd sam się zatrzyma, oraz jak długo będzie przyśpieszał
    // W związku z tym, że tworzymy grę, w której poruszamy się tylko po X i Y to zaznaczamy:
    // "Freeze Position Y" oraz "Freeze Rotation X", "Freeze Rotation Z";

    [Tooltip("Numer gracza. Przykład: gracz 1 będzie kierował klawiszami z dopiskiem 1 (sprawdź Project Settings -> Input)")]
    public int playerNumber = 1;
    [Tooltip("Prędkość poruszania się pojazdu")]
    public float speed = 925f;
    [Tooltip("Prędkość skręcania pojazdu")]
    public float turnSpeed = 180f;
    [Tooltip("Maksymalna prędkość, którą może osiągnąć pojazd")]
    public float maxVelocity = 3f;

    private string kMovementAxisName;
    private string kTurnAxisName;
    private string jMovementAxisName;
    private string jTurnAxisName;
    private new Rigidbody rigidbody;
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
        kMovementAxisName = "KVertical" + playerNumber;
        kTurnAxisName = "KHorizontal" + playerNumber;
        jMovementAxisName = "JVertical" + playerNumber;
        jTurnAxisName = "JHorizontal" + playerNumber;

    }

    void Update()
    {
        // Input gracza
        movementInputValue = 0f;
        turnInputValue = 0f;
        movementInputValue += Input.GetAxis(kMovementAxisName);
        movementInputValue += Input.GetAxis(jMovementAxisName);
        turnInputValue += Input.GetAxis(kTurnAxisName);
        turnInputValue += Input.GetAxis(jTurnAxisName);
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
