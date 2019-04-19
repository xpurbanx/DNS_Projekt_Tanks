using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Bullet")]

public class Building : MonoBehaviour
{
    // PRYWATNE ATRYBUTY KLASY W TYM PLIKU:
    internal float hp;

    // PUBLICZNE ODPOWIEDNIKI ATRYBUTÓW KLASY:
    [Tooltip("Wytrzymałość budynku")]
    public float health = 100;

    // Czy budynek został zniszczony
    private bool isDestroyed = false;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        hp = health;
    }

    void Update()
    {
        // Jeżeli budynek został właśnie zniszczony
        if (!isDestroyed && hp <= 0)
        {
            DestroyBuilding();
        }
    }

    private void DestroyBuilding()
    {
        // Zamienia budynek na kawałki, plus wywołuje dodatkowe efekty, particle
        gameObject.GetComponent<SpawnFractured>().SpawnFracturedObject();
    }
}
