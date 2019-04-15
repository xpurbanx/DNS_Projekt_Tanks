using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // NIEDZIEDZICZONE
    int health; // Zdrowie
    int damage; // Zadawane
    float speed;
<<<<<<< HEAD

<<<<<<< HEAD
    [Tooltip("0 - niezdefiniowany, 1 - jeep, 2 - czołg, 3 - helikopter")]
    public int vehicleType = 0;
=======
>>>>>>> parent of 9f9fae0... Modyfikowanie atryb. osobnych skryptów z poziomu klasy

    // PUBLICZNE:

<<<<<<< HEAD
    [Tooltip("Obrażenia zadawane przez KM")]
    public float machineGunDamage = 2.85f;

    [Tooltip("Obrażenia zadawane przez działo czołgowe")]
    public float antiTankDamage = 52f;

    [Tooltip("Prędkość poruszania się pojazdu")]
    public float speed = 400f;

    [Tooltip("Prędkość skręcania pojazdu")]
    public float turnSpeed = 150f;

    [Tooltip("Maksymalna prędkość, którą może osiągnąć pojazd")]
    public float maxVelocity = 3f;

    [Tooltip("Szybkostrzelność pojazdu")]
    public float firingCooldown = 0.1f;

    [Tooltip("0 - pojazd nie strzela, 1 - amunicja do KM-u, 2 - amunicja PPANC")]
    public int fireType = 0;    // Gdy jeep strzela w czołg wystarczy sprawdzić czy fireType = 1, wtedy ustawiamy w skrypcie strzelania, że jeep nie zniszczy czołgu

    // KONSTRUKTOR UNITY:

    void Start()
    {
        hp = health;
        mgdmg = machineGunDamage;
        atdmg = antiTankDamage;
        vehType = vehicleType;
        PlayerMovement.instance.speed = speed;
        PlayerMovement.instance.turnSpeed = turnSpeed;
        PlayerMovement.instance.maxVelocity = maxVelocity;
        PlayerFiring.instance.firingCooldown = firingCooldown;
        PlayerFiring.instance.fireType = fireType;
    }

    // PRYWATNE ATRYBUTY NIEPOCHODZĄCE ZE SKRYPTÓW ZEWNĘTRZNYCH
    int vehType; // Typ pojazdu: 0 = niezdefiniowany, 1 = jeep, 2 = czołg, 3 = helikopter
    int hp;
    float mgdmg;
    float atdmg;
=======
    // PUBLICZNE:

    public float SPD = 3000f;

    public Vehicle()
    {
        speed = SPD;
        health = 100;
        damage = 0;
       // spd = 600f;
    }

=======
    public float SPD = 3000f;

    public Vehicle()
    {
        speed = SPD;
        health = 100;
        damage = 0;
       // spd = 600f;
    }

>>>>>>> parent of 9f9fae0... Modyfikowanie atryb. osobnych skryptów z poziomu klasy
    void Update()
    {
        PlayerMovement.instance.speed = SPD;
    }
<<<<<<< HEAD
>>>>>>> parent of 9f9fae0... Modyfikowanie atryb. osobnych skryptów z poziomu klasy
=======
>>>>>>> parent of 9f9fae0... Modyfikowanie atryb. osobnych skryptów z poziomu klasy
}




