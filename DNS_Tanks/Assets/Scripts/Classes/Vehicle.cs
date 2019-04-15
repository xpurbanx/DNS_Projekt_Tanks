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
}


