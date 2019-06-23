using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("PlayerButtons")]
[assembly: InternalsVisibleTo("Vehicle")]
[assembly: InternalsVisibleTo("LockActions")]

public class Respawn : MonoBehaviour
{
    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    public List<GameObject> vehicles;
    public string spawnerTag;
    public int startVehicle = 0;
    public int respawnTimer = 2;
    internal bool isSpawning = false;
    internal Transform spawner;
    internal Vector3 spawnLocation;

    void Awake()
    {
        Launch();
    }

    internal void Launch()
    {
        spawner = GameObject.FindGameObjectWithTag(spawnerTag).transform;
        spawnLocation = new Vector3(spawner.position.x, spawner.position.y, spawner.position.z);
        SpawnVehicle(startVehicle);
        if (transform.GetChild(0).GetComponent<PlayerFiring>() != null)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            if (!GameObject.FindGameObjectWithTag("GameController").GetComponent<WinManager>().gameEnded)
            {
                GetComponentInChildren<VehSwitchAvailable>().OpenMenu();
            }
        }
    }

    public void SpawnVehicle(int vehicleIndex)
    {
        transform.position = spawner.position;
        Instantiate(vehicles[vehicleIndex], spawnLocation, transform.rotation, transform);
        GetComponent<CurrentVehicle>().UpdateCurrentVeh();
        GetComponentInChildren<CamFollow>().UpdateCurrentVeh();
        isSpawning = false;
        Lock().aimingLocked = false;
        Lock().movementLocked = false;
        Lock().menusLOCKED = false;
        Lock().shootingLOCKED = false;
        Lock().shootingLocked = false;
    }

    public void RespawnPlayer()
    {
        if (!isSpawning)
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

    public GameObject CurrentVeh()
    {
        GameObject veh = transform.GetChild(0).gameObject;
        return veh;
    }
}
