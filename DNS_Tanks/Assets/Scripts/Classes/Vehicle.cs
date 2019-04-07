using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClasses
{
    public class Vehicle : PlayerMovement
    {
        // PRYWATNE:
        int hp; // Zdrowie
        int dmg; // Zadawane obrażenia
        int spd; // Prędkość pojazdu

        void Movement() {; } // Poruszanie pojazdem
        void Shoot() {; } // Strzel
        void PickUp() {; } // Podnieś przedmiot (np. flagę)

        // KONSTRUKTOR I DESTRUKTOR:
        public Vehicle()
        {
            hp = 100;
            dmg = 0;
            spd = 50;
        }
        
    }
}


