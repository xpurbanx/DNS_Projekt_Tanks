using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Bullet")]

public class Vehicle : MonoBehaviour
{
    // PRYWATNE ATRYBUTY KLASY W TYM PLIKU:
    internal int vehType;
    internal float hp, damage;

    // PUBLICZNE ODPOWIEDNIKI ATRYBUTÓW KLASY:
    [Header("Właściwości pojazdu:")]
    ////////////////////////////////
    [Tooltip("Do którego gracza należy pojazd")]
    public int playerNumber = 0;

    [Tooltip("Typ pojazdu (0: niezdefiniowany, 1: jeep, 2: czołg, 3: śmigłowiec)")]
    public int vehicleType = 0;

    [Tooltip("Wytrzymałość pojazdu")]
    public float health = 100;

    [Tooltip("Prędkość poruszania się pojazdu")]
    public float speed = 1000f;

    [Tooltip("Prędkość skręcania pojazdu")]
    public float turnSpeed = 180f;

    [Tooltip("Maksymalna prędkość, którą może osiągnąć pojazd")]
    public float maxVelocity = 3f;

    [Header("Właściwości broni:")]
    //////////////////////////////
    [Tooltip("Obrażenia zadawane przez działko maszynowe")]
    public float damageMG = 2.85f;

    [Tooltip("Obrażenia zadawane przez działo ppanc")]
    public float damageAT = 52f;

    [Tooltip("Szybkostrzelność pojazdu")]
    public float firingCooldown = 5f;

    [Tooltip("Szybkość obrotu broni")]
    public float turnTurretSpeed = 200f;

    [Tooltip("Prędkość początkowa pocisku")]
    public float bulletVelocity = 10f;

    // Zarządzane skrypty
    private PlayerMovement playerMovement;
    private PlayerFiring playerFiring;
    private PlayerRotateTurret playerRotateTurret;
    private Rigidbody rb;

    private void Awake()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerFiring = gameObject.GetComponent<PlayerFiring>();
        playerRotateTurret = gameObject.GetComponent<PlayerRotateTurret>();
        rb = GetComponent<Rigidbody>();
        gameObject.transform.SetSiblingIndex(0); // ma sprawic, ze obiekt z tym skryptem bedzie na gorze w hierarhii

        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    void Start()
    {
        vehType = vehicleType;
        switch(vehType)
        {
            case 1:
                damage = damageMG;
                break;
            case 2:
                damage = damageAT;
                break;
            case 3:
                damage = 0f; // Na razie nie ustalono broni dla śmigłowca
                break;
            default:
                damage = 0f;
                break;
        }
        hp = health;
        playerMovement.speed = speed;
        playerMovement.turnSpeed = turnSpeed;
        playerMovement.maxVelocity = maxVelocity;

        playerFiring.firingCooldown = firingCooldown;
        playerFiring.damage = damage;
        playerFiring.startVelocity = bulletVelocity;
        playerFiring.playerNumber = playerNumber;
        playerRotateTurret.turnTurretSpeed = turnTurretSpeed; 

        if (damage == 0f)
            Debug.Log("Pojazd \""+gameObject.name+"\" nie zadaje obrażeń. Może nie zdefiniowałeś jego typu w polu \"Vehicle Type\"?");
    }

    private void Update()
    {
        if (hp <= 0)
            Die();
        Debug.Log(gameObject.name+": "+ hp);
    }

    private void Die()
    {
        Destroy(gameObject);
        GetComponentInParent<Respawn>().RespawnPlayer();
    }

    public float GetHealth()
    {
        return hp;
    }

    public int GetSpeed()
    {
        int currentSpeed;
        currentSpeed = (int)rb.velocity.magnitude;
        //currentSpeed = System.Math.Round(currentSpeed, 2);
        return currentSpeed;
    }
}

/*
Ustawianie wartości z zewnętrznych skryptów (np. PlayerMovement.cs) w klasach pojazdów (np. Vehicle.cs) - dla potomnych.

1. W skrypcie zewnętrznym dodaj klauzule: "using System.Runtime.CompilerServices;" oraz "[assembly: InternalsVisibleTo("nazwa_klasy_pojazdu")]"

2. Wszystkie atrybuty prywatne, które chcesz modyfikować w klasie pojazdu, w skrypcie zewnętrznym ustaw na modyfikator internal. Modyfikator internal działa tak jak private,
   ale jest publiczny dla klasy wymienionej w klauzuli "[assembly: InternalsVisibleTo("nazwa_klasy_pojazdu")]" (jest to taki odpowiednik przyjaźni z C++, ale ch*jowszy)

3. W skrypcie zewnętrznym utwórz następującą instancję: "public static PlayerMovement instance;"

4. W funkcji void Awake() w skrypcie zewnętrznym ustaw instancję w taki sposób: "instance = this;" - spowoduje to jej ustawienie jeszcze przed wywołaniem konstruktora, który
   z tej instancji będzie korzystał.

5. W klasie pojazdu utwórz:
            - prywatne atrybuty, których nie ma w skrypcie zewnętrznym (nie tworzymy żadnych kopii atrybutów prywatnych ze skryptu zewnętrznego)
            - publiczne pola, które będą ustawiały prywatne atrybuty z poziomu inspectora (zauważ, że publiczne atrybuty to odpowiedniki WSZYSTKICH potrzebnych atrybutów:
              i ze skryptu zewn., i z klasy pojazdu (jest tak, bo przecież wszystkie chcemy ustawiać z poziomu inspectora w klasie pojazdu)
            - konstruktor Unity: void Start(), który ustawia prywatne atrybuty z klasy pojazdu (żadna magia) oraz prywatne atrybuty ze skryptu zewnętrznego
              (np. "PlayerMovement.instance.speed = speed;")

6. Komentuj, subskrybuj, klikaj żółty, magiczny guziczek.
*/




