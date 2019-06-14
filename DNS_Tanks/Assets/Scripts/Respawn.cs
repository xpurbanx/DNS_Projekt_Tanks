using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Player1Buttons")]

public class Respawn : MonoBehaviour
{


    public List<GameObject> vehicles;
    public string spawnerTag;
    public int startVehicle = 0;
    public int respawnTimer = 2;
    internal bool isSpawning = false;
    Transform spawner;
    Vector3 spawnLocation;
    // Start is called before the first frame update

    void Awake()
    {
        Launch();
    }

    internal void Launch()
    {
        spawner = GameObject.FindGameObjectWithTag(spawnerTag).transform;
        spawnLocation = new Vector3(spawner.position.x, spawner.position.y, spawner.position.z);
        SpawnVehicle(startVehicle);
    }

    public void SpawnVehicle(int vehicleIndex)
    {
        Debug.Log(transform.name + "TO TRANSFORM JEST");
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
    internal void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(spawnLocation, 1f);
    }
}
