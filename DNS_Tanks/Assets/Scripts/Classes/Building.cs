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

    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        hp = health;
    }

    private void DestroyBuilding()
    {
        // Usuwa budynek z listy budynków
        GameObject.FindGameObjectWithTag("GameController").GetComponent<FlagManager>().DeleteBuildingFromArray(gameObject);

        // Zamienia budynek na kawałki, plus wywołuje dodatkowe efekty, particle
        if (gameObject.GetComponent<SpawnFractured>() != null)
        {
            gameObject.GetComponent<SpawnFractured>().SpawnFracturedObject();
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
