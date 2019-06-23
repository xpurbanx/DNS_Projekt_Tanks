using System.Runtime.CompilerServices;
using UnityEngine;
[assembly: InternalsVisibleTo("Bullet")]

public class Building : MonoBehaviour
{
    // PRYWATNE ATRYBUTY KLASY W TYM PLIKU:
    internal float hp;
    internal bool hasFlag;
    [Header("JEŻELI TO MA BYĆ BUDYNEK Z FLAGĄ,", order = 1)]
    [Header("nie zapomnij dodać go do listy budynków", order = 2)]
    [Header("posiadających flagę w game managerze.", order = 3)]
    [Space(10, order = 4)]


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
        ActiveEntities.Instance.AddToList(this.tag, this.gameObject);
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
