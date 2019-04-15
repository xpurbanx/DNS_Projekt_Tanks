using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // PUBLICZNE ODPOWIEDNIKI ATRYBUTÓW KLASY:

    [Tooltip("Wytrzymałość pojazdu")]
    public int health = 100;

    [Tooltip("Obrażenia zadawane przez pojazd")]
    public int damage = 0;

    [Tooltip("Prędkość poruszania się pojazdu")]
    public float speed = 5000f;

    [Tooltip("Prędkość skręcania pojazdu")]
    public float turnSpeed = 180f;

    [Tooltip("Maksymalna prędkość, którą może osiągnąć pojazd")]
    public float maxVelocity = 3f;

    [Tooltip("Szybkostrzelność pojazdu")]
    public float firingCooldown = 5f;

    // KONSTRUKTOR UNITY:

    void Start()
    {
        hp = health;
        dmg = damage;
        PlayerMovement.instance.speed = speed;
        PlayerMovement.instance.turnSpeed = turnSpeed;
        PlayerMovement.instance.maxVelocity = maxVelocity;
        //PlayerFiring.instance.firingCooldown = firingCooldown; normalnie to działa, ale gdy usunę Tank 1 to wywala błąd bo nie może znaleźć tego skryptu (bo do tank 2 nie jest on przypisany)
    }

    // PRYWATNE ATRYBUTY NIEPOCHODZĄCE ZE SKRYPTÓW ZEWNĘTRZNYCH
    int hp;
    int dmg;
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




