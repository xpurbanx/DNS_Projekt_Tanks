using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Vehicle")]
[assembly: InternalsVisibleTo("PlayerIsGrounded")]

public class PlayerMovement : MonoBehaviour
{
    // Na sposób poruszania ma też wpływ samo Rigibody, jego parametry można zmienić w Unity, w inspektorze
    // Czyli: Drag - tarcie, po jakim czasie od puszczenia przycisków pojazd sam się zatrzyma, oraz jak długo będzie przyśpieszał
    // W związku z tym, że tworzymy grę, w której poruszamy się tylko po X i Y to zaznaczamy:
    // "Freeze Position Y" oraz "Freeze Rotation X", "Freeze Rotation Z";
    // ALE!!! Te modele są trochę poprzekręcane względem osi Y
    // ALE!!! #2 W unity jest tak, że pomimo tego, że obiekt ma zaznaczony freeze rotation, za pomocą skryptu można zmieniać jego rotację (w tym przypadku skryptu PlayerMovement)
    // Więc na razie po prostu zablokowałem całkowicie rotację, co niestety brzydziej wygląda (mniej realistyczne uderzanie w inne obiekty)

    // Prywatne atrybuty zmieniane w Vehicle.cs
    internal float speed;
    internal float turnSpeed;
    internal float maxVelocity;

    // Prywatny atrybut zmieniany przez skrypt w gąsiennicach
    internal bool touchingGroundOne;
    internal bool touchingGroundTwo;

    // Vertical - oś od poruszania się na klawiaturze
    // Trigger - "oś" od poruszania się
    // Horizontal - oś od skręcania
    private new Rigidbody rigidbody;
    private float movementInputValue;
    private float turnInputValue;
    private PlayerInputSetup playerInput;
    
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
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    void Update()
    {
        // Input gracza
       
        movementInputValue = playerInput.Trigger();
        turnInputValue = playerInput.Horizontal();
    }

    private void FixedUpdate()
    {
        // Poruszanie się czołgu, jechanie prosto do tyłu i skręcanie
        if (touchingGroundOne || touchingGroundTwo)
        {
            Move();
            Turn();
        }

        // Maksymalna prędkość pojazdu
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVelocity);
    }

    private void Move()
    {
        // Poruszanie się prosto (lub do tyłu, zależy od movementInputValue) z określoną prędkością
        Vector3 movement = transform.forward * movementInputValue * speed * 1000f;

        // Poruszanie obiektem jest oparte na dodawaniu siły
        rigidbody.AddForce(movement);
    }

    private void Turn()
    {
        // Stopień skręcania
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
        return;
    }
}
