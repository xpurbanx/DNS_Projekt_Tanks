﻿using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Bullet")]
[assembly: InternalsVisibleTo("PlayerButtons")]

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

    [Tooltip("Typ pojazdu (1: jeep, 2: czołg,")]
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

    [Tooltip("Zasięg pocisku")]
    public float bulletRange = 30f;

    // Zarządzane skrypty
    private PlayerMovement playerMovement;
    private PlayerFiring playerFiring;
    private PlayerRotateTurret playerRotateTurret;
    private PlayerInputSetup playerInput;
    private Rigidbody rb;

    private void Awake()
    {
        playerInput = gameObject.GetComponentInParent<PlayerInputSetup>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerFiring = gameObject.GetComponent<PlayerFiring>();
        playerRotateTurret = gameObject.GetComponent<PlayerRotateTurret>();
        rb = GetComponent<Rigidbody>();
        gameObject.transform.SetSiblingIndex(0); // ma sprawic, ze obiekt z tym skryptem bedzie na gorze w hierarhii

        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
    private void OnEnable()
    {
        ActiveEntities.Instance.AddToList(this.tag, this.gameObject);
    }

    void Start()
    {
        vehType = vehicleType;
        switch (vehType)
        {
            case 1:
                damage = damageMG;
                break;
            case 2:
                damage = damageAT;
                break;
            case 3:
                damage = damageAT; // Na razie nie ustalono broni dla śmigłowca
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

        GetComponentInParent<HUD>().UpdateHealthBar(hp);

        if (playerRotateTurret != null)
        {
            playerRotateTurret.turnTurretSpeed = turnTurretSpeed;
        }
    }

    internal void ForVehicleChooseDestroy()
    {
        GetComponentInParent<PlayerFlagManager>().DropFlagAfterDeath(transform.position);
        Destroy(gameObject);
        ActiveEntities.Instance.RemoveFromList(this.tag, this.gameObject);
    }

    private void DestroyVehicle()
    {
        DecreaseLifes();
        GetComponentInParent<PlayerFlagManager>().DropFlagAfterDeath(transform.position);
        GetComponent<Explosion>().Explode(false, false);
        GameObject.FindGameObjectWithTag("Map Panel " + playerFiring.playerNumber).GetComponentInParent<OverlayEnable>().ClosePanel();
        Lock().mapLocked = true;
        Lock().aimingLocked = true;
        Lock().movementLocked = true;
        Lock().menusLOCKED = true;
        Lock().shootingLOCKED = true;
        Destroy(gameObject);
        GetComponentInParent<Respawn>().Launch();
        ActiveEntities.Instance.RemoveFromList(this.tag, this.gameObject);
    }



    //public int GetSpeed()
    //{
    //    int currentSpeed;
    //    currentSpeed = (int)rb.velocity.magnitude;
    //    //currentSpeed = System.Math.Round(currentSpeed, 2);
    //    return currentSpeed;
    //}

    public void Damage(float damage)
    {
        hp -= damage;
        GetComponentInParent<HUD>().UpdateHealthBar(hp);
        CheckIfDestroyed();
    }

    private void CheckIfDestroyed()
    {
        if (hp <= 0)
            DestroyVehicle();
    }

    private void DecreaseLifes()
    {
        if (vehicleType == 1)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LifesManager>().JeepDeath(playerNumber);
        }

        else if (vehicleType == 2)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LifesManager>().TankDeath(playerNumber);
        }

        else if (vehicleType == 3)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<LifesManager>().HeavyTankDeath(playerNumber);
        }
    }

    public SuppliesAvailable SuppliesAvailable()
    {
        SuppliesAvailable suppliesAvailable = GameObject.FindGameObjectWithTag("Supplies " + playerFiring.playerNumber).GetComponent<SuppliesAvailable>();
        return suppliesAvailable;
    }

    void InstantiateSupply(Vector3 pos, GameObject pref)
    {
        Instantiate(pref, pos, transform.rotation, transform);
    }

    public void SetSupply(Vector3 pos, GameObject pref)
    {
        Lock().mapLocked = true;
        Lock().shootingLocked = true;
        Lock().menusLocked = true;
        SuppliesAvailable().hasSupply = true;
        InstantiateSupply(pos, pref); // Utworzenie prefaba supply'a w przed pojazdem
        Transform supply = gameObject.transform.GetChild(1); // Oznaczenie supply'a
        supply.rotation = gameObject.transform.rotation;

        Rigidbody r = supply.gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody; // Dodanie rigidbody, zamrożenie wszystkiego, ustawienie trybu kolizji
        r.constraints = RigidbodyConstraints.FreezeAll;
        r.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        Material newMaterial; // Utworzenie nowego materiału
        newMaterial = GameObject.FindGameObjectWithTag("Transparent").GetComponent<MeshRenderer>().material; // Nadanie właściwości nowemu materiałowi

        supply.tag = "Untagged"; // Usunięcie taga w celu ignorowania supply'a przez wrogie wieżyczki

        MeshRenderer[] renderers = supply.transform.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i <= renderers.Length - 1; i++)
        {
            renderers[i].material = newMaterial;
            renderers[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off; // Nadanie przezroczystości supply'owi oraz wyłączenie cieni
        }

        BoxCollider[] colliders = supply.transform.GetComponentsInChildren<BoxCollider>();
        for (int i = 0; i <= colliders.Length - 1; i++)
        {
            colliders[i].isTrigger = true; // Przełączenie kolizji na trigger
        }

        if (supply.GetComponent<AITower>() != null) // Wyłączenie właściwości i AI, jeśli wybraliśmy wieżyczkę
        {
            supply.GetComponent<AITower>().enabled = false;
            supply.GetComponent<Building>().enabled = false;
        }
        StartCoroutine(Wait());

    }

    public void PutSupply()
    {
        Transform supply = gameObject.transform.GetChild(1); // Oznaczenie supply'a jako duszka
        Vector3 supplyPos = new Vector3(supply.position.x, 0, supply.position.z);
        GameObject chosenSupply = GameObject.FindGameObjectWithTag("Supplies " + playerFiring.playerNumber).GetComponent<PlayerButtons>().prefab;

        if (GetComponentInChildren<SupplyCollision>().colliding == false)
        {
            GameObject instance = Instantiate(chosenSupply, supplyPos, supply.transform.rotation);
            ActiveEntities.Instance.AddToList(supply.tag, supply.gameObject);
            supply.position = supplyPos;
            Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
            Destroy(rigidbody); // Usunięcie fizyki
            supply = gameObject.transform.GetChild(1);
            Destroy(supply.gameObject); // Zniszczenie "duszka"
            StartCoroutine(Wait2());
        }
        else return;
    }

    public IEnumerator Wait()
    {
        SuppliesAvailable().canBeSet = false;
        yield return new WaitForSecondsRealtime(1);
        SuppliesAvailable().canBeSet = true;
    }

    public IEnumerator Wait2()
    {
        SuppliesAvailable().hasSupply = false;
        SuppliesAvailable().canBeSet = false;
        yield return new WaitForSecondsRealtime(1);
        Lock().shootingLocked = false;
        Lock().mapLocked = false;
        Lock().menusLocked = false;
    }

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    private void Update()
    {
        if (SuppliesAvailable().hasSupply && (playerInput.AButtonJ() || playerInput.AButtonK()) && SuppliesAvailable().canBeSet)
            PutSupply();
        if (SuppliesAvailable().hasSupply)
        {
            Transform supply = gameObject.transform.GetChild(1); // Oznaczenie supply'a
            supply.rotation = gameObject.transform.rotation;
        }
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




