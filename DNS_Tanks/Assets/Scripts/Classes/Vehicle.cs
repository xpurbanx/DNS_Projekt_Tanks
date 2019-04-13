using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // NIEDZIEDZICZONE
    int health; // Zdrowie
    int damage; // Zadawane
    float speed;

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




