using System.Runtime.CompilerServices;
using System.Collections.Generic;
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


    [Tooltip("Dotyczy budynkow z czesciami jak wall.Parts musza miec collidery i rigidbody z zaznaczonym Trigger i zamrozonymi pozycjami")]
    public bool hasParts = false;
    [Tooltip("Z jaka moca rozpada sie budynek")]
    public float destroyExplosionForce = 2f;
    [Tooltip("Z jaka moca rozpada sie budynek")]
    public float explosionRadius = 10f;
    [Tooltip("Z jaka moca rozpada sie budynek")]
    public float partLifetime = 5f;

    private SpawnFractured fractured;
    private Explosion explosion;
    void Start()
    {
        //gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        hp = health;
        fractured = GetComponent<SpawnFractured>();
        ActiveEntities.Instance.AddToList(this.tag, this.gameObject);
        if (GetComponent<Explosion>() != null) explosion = GetComponent<Explosion>();
    }
    private void OnEnable()
    {

    }

    private void DestroyBuilding()
    {
        // Usuwa budynek z listy budynków
        if (hasFlag)
        {
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<FlagManager>().DeleteBuildingFromArray(gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FlagManager>().SpawnFlag(gameObject);
        }

        // Zamienia budynek na kawałki, plus wywołuje dodatkowe efekty, particle
        if (fractured != null)
        {
            fractured.SpawnFracturedObject();
        }

        if (hasParts == true)
        {
            if (explosion != null)
                explosion.Explode(false, false);
            foreach(Collider collider in GetComponents<Collider>())
            {
                Destroy(collider);
            }

            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                if (child.GetComponent<MeshCollider>() != null)
                {
                    child.GetComponent<MeshCollider>().isTrigger = false;
                }
                if (child.GetComponent<Rigidbody>() != null)
                {
                    child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    child.GetComponent<Rigidbody>().AddExplosionForce(destroyExplosionForce, transform.position, explosionRadius);
                }

                if (child.tag == "Marker") // Usunięcie markera z mapy
                    Destroy(child);

                Destroy(child, partLifetime);
            }
            return;

        }
        if(explosion != null)
           explosion.Explode(true, true);
        Destroy(gameObject);

    }

    private void CheckIfDestroyed()
    {
        if (hp <= 0)
        {
            DestroyBuilding();
            ActiveEntities.Instance.RemoveFromList(tag, gameObject);
        }

    }

    public void Damage(float damage)
    {
        hp -= damage;
        CheckIfDestroyed();
    }
}
