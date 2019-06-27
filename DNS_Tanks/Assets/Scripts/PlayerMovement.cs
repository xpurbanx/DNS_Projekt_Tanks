using System.Collections;
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

    // Kod wymagany do blokady sterowania

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    // Prywatne atrybuty zmieniane w Vehicle.cs
    internal float speed;
    internal float turnSpeed;
    internal float maxVelocity;

    // Vertical - oś od poruszania się na klawiaturze
    // Trigger - "oś" od poruszania się
    // Horizontal - oś od skręcania
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    private PlayerInputSetup playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Po włączeniu skryptu upewniamy się, że na czołg mogą działać siły i zerujemy aktualnie działające siły
    private void OnEnable()
    {
        rb.isKinematic = false;
        movementInputValue = 0f;
        turnInputValue = 0f;
    }

    void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
        StartCoroutine(RigibodyFreezePositionY());
    }

    void Update()
    {
        // Input gracza

        movementInputValue = playerInput.LeftTrigger();
        if (playerInput.LeftBumper())
        {
            Debug.Log("BUMPER");
            movementInputValue = -1.0f;
        }
        movementInputValue += playerInput.VerticalK();

        turnInputValue = playerInput.Horizontal();
    }

    private void FixedUpdate()
    {
        // Poruszanie się czołgu, jechanie prosto do tyłu i skręcanie
        if (Lock().allLocked == false && Lock().movementLocked == false)
        {
            Move();
            Turn();
        }

        // Dodatkowa grawitacja (?)
        rb.AddForce(-transform.up * 5, ForceMode.Acceleration);
        // Maksymalna prędkość pojazdu
        MaxSpeed();
    }

    private void Move()
    {
        // Poruszanie się prosto (lub do tyłu, zależy od movementInputValue) z określoną prędkością
        Vector3 movement = transform.forward * movementInputValue * speed * 1000f;

        // Poruszanie obiektem jest oparte na dodawaniu siły
        rb.AddForce(movement);
    }

    private void Turn()
    {
        // Stopień skręcania
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        rb.MoveRotation(rb.rotation * turnRotation);
        return;
    }

    private void MaxSpeed()
    {
        Vector3 velocity = rb.velocity;
        float y = velocity.y;
        velocity.y = 0f;
        velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
        velocity.y = y;
        rb.velocity = velocity;
    }

    private IEnumerator RigibodyFreezePositionY()
    {
        yield return new WaitForSeconds(0.5f);
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.01f, transform.localPosition.z);
    }
}
