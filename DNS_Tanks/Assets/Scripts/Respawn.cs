﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public List<GameObject> vehicles;
    public string spawnerTag;
    public int startVehicle = 0;
    public int respawnTimer = 2;
    private bool isSpawning = false;
    Transform spawner;
    Vector3 spawnLocation;
    // Start is called before the first frame update

    void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag(spawnerTag).transform;
        spawnLocation = new Vector3(spawner.position.x, spawner.position.y, spawner.position.z);
        SpawnVehicle(startVehicle);
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
}
