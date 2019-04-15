using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClasses
{

    public class Vehicle : PlayerMovement
    {
        // NIEDZIEDZICZONE
        int health; // Zdrowie
        int damage; // Zadawane

        // PUBLICZNE:

        [Header("Atrybuty klasy:")]
        public int HEALTH = 100;
        public int DAMAGE = 0;
        public float SPEED = 600f;
        public float TURN_SPEED = 150f;
        public float MAX_VELOCITY = 30f;

        public Vehicle()
        {
            health = HEALTH;
            damage = DAMAGE;
            speed = SPEED;
            turnSpeed = TURN_SPEED;
            maxVelocity = MAX_VELOCITY;
        }

    } 

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
    int dmg;

}


