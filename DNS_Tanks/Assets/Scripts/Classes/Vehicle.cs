using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    // NIEDZIEDZICZONE
    int health; // Zdrowie
    int damage; // Zadawane
    float speed;



    [Tooltip("0 - niezdefiniowany, 1 - jeep, 2 - czołg, 3 - helikopter")]
    public int vehicleType = 0;


    // PUBLICZNE:


    [Tooltip("Obrażenia zadawane przez KM")]
    public float machineGunDamage = 2.85f;

    [Tooltip("Obrażenia zadawane przez działo czołgowe")]
    public float antiTankDamage = 52f;

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
        PlayerFiring.instance.firingCooldown = firingCooldown;
    }

    // PRYWATNE ATRYBUTY NIEPOCHODZĄCE ZE SKRYPTÓW ZEWNĘTRZNYCH
    int hp;
    float mgdmg;
    float atdmg;

    // PUBLICZNE:

    int dmg;
}

    public float SPD = 3000f;

    public Vehicle()
    {
        speed = SPD;
        health = 100;
        damage = 0;
       // spd = 600f;
    }

    public float SPD = 3000f;

    public Vehicle()
    {
        speed = SPD;
        health = 100;
        damage = 0;
       // spd = 600f;
    }

    void Update()
    {
        PlayerMovement.instance.speed = SPD;
    }

}



    // PUBLICZNE:

    public float SPD = 3000f;

    public Vehicle()
    {
        speed = SPD;
        health = 100;
        damage = 0;
       // spd = 600f;
    }

    void Update()
    {
        PlayerMovement.instance.speed = SPD;
    }
}




