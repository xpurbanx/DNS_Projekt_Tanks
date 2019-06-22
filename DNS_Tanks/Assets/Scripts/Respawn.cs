using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("PlayerButtons")]
[assembly: InternalsVisibleTo("Vehicle")]
[assembly: InternalsVisibleTo("LockActions")]

public class Respawn : MonoBehaviour
{   
=======

public class Respawn : MonoBehaviour
{
>>>>>>> parent of 3a6fbeb... Request #48 (Mix zmian Michała, Mikołaja i moich, rozwiązane konflikty i naprawione małe bugi)
    public List<GameObject> vehicles;
    public string spawnerTag;
    public int startVehicle = 0;
    public int respawnTimer = 2;
<<<<<<< HEAD
    internal bool isSpawning = false;
    internal Transform spawner;
    internal Vector3 spawnLocation;
=======
    private bool isSpawning = false;
    Transform spawner;
    Vector3 spawnLocation;
    // Start is called before the first frame update
>>>>>>> parent of 3a6fbeb... Request #48 (Mix zmian Michała, Mikołaja i moich, rozwiązane konflikty i naprawione małe bugi)

    void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag(spawnerTag).transform;
        spawnLocation = new Vector3(spawner.position.x, spawner.position.y, spawner.position.z);
        SpawnVehicle(startVehicle);
        if(transform.GetChild(0).GetComponent<PlayerFiring>())
        {
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponentInChildren<VehSwitchAvailable>().OpenMenu();
        }
    }

    public void SpawnVehicle(int vehicleIndex)
    {
        transform.position = spawner.position;
        Instantiate(vehicles[vehicleIndex], spawnLocation, transform.rotation, transform);
        GetComponent<CurrentVehicle>().UpdateCurrentVeh();
        GetComponentInChildren<CamFollow>().UpdateCurrentVeh();
        isSpawning = false;
    }

    public void RespawnPlayer()
    {
        if(!isSpawning)
         StartCoroutine(Respawning());
    }

    public IEnumerator Respawning() // czeka 'respawnTimer' sekund
    {
       isSpawning = true;
       yield return new WaitForSeconds(respawnTimer);
       SpawnVehicle(startVehicle);
    }

    [ExecuteInEditMode]
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(spawnLocation, 1f);
    }

    public GameObject CurrentVeh()
    {
        GameObject veh = transform.GetChild(0).gameObject;
        return veh;
    }
}
