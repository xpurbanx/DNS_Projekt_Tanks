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

    [Tooltip("Numer gracza, do którego należy budynek")]
    public int playerNumber = 0;

    // Czy budynek został zniszczony
    private bool isDestroyed = false;
    private SpawnFractured fractured;

    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        hp = health;
        fractured = GetComponent<SpawnFractured>();
    }

    private void DestroyBuilding()
    {
        // Zamienia budynek na kawałki, plus wywołuje dodatkowe efekty, particle
        Destroy(gameObject);
        if(fractured != null)
            fractured.SpawnFracturedObject();
        
    }

    private void CheckIfDestroyed()
    {
        if (hp <= 0)
            DestroyBuilding();
    }

    public void Damage(float damage)
    {
        hp -= damage;
        CheckIfDestroyed();
    }
}
