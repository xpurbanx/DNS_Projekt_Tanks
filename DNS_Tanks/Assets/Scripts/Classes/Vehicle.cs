using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClasses
{
    public class Vehicle : PlayerMovement
    {
        // PRYWATNE:
        int health; // Zdrowie
        int damage; // Zadawane

        // PUBLICZNE:

        [Header("Atrybuty klasy:")]
        public int HP = 100;
        public int DMG = 0;

        public Vehicle()
        {
            health = HP;
            damage = DMG;
        }
    }
}


