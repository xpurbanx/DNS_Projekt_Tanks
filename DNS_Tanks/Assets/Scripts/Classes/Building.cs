using System.Runtime.CompilerServices;
using UnityEngine;
[assembly: InternalsVisibleTo("Bullet")]

public class Building : MonoBehaviour
{
    // PRYWATNE ATRYBUTY KLASY W TYM PLIKU:
    internal float hp;
    internal bool hasFlag;

    // PUBLICZNE ODPOWIEDNIKI ATRYBUTÓW KLASY:
    [Tooltip("Wytrzymałość budynku")]
    public float health = 100;

    [Tooltip("Numer gracza, do którego należy budynek")]
    public int playerNumber = 0;

    private SpawnFractured fractured; 
    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        hp = health;
        fractured = GetComponent<SpawnFractured>();
    }

    private void DestroyBuilding()
    {
        // Usuwa budynek z listy budynków
        GameObject.FindGameObjectWithTag("GameController").GetComponent<FlagManager>().DeleteBuildingFromArray(gameObject);

        // Zamienia budynek na kawałki, plus wywołuje dodatkowe efekty, particle
        if (fractured != null)
        {
            fractured.SpawnFracturedObject();
        }

        if (hasFlag)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FlagManager>().SpawnFlag(gameObject);
        }

        Destroy(gameObject);
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
