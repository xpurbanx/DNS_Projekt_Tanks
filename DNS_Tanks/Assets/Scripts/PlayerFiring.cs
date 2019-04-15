﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    private PlayerInputSetup playerInput;
    public GameObject bulletPrefab;
    private Rigidbody rigidbody;
    // Opóźnienie w wystrzeliwaniu pocisku, zarządzane też przez klasę Vehicle
    public float firingCooldown = 5f;
    private float timeStamp = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerInput = GetComponent<PlayerInputSetup>();
    }
    private void FixedUpdate()
    {
        Fire();
    }

    private void Fire()
    {
        // Pocisk zostaje wystrzelony w momencie w którym dostaje input dla AButton
        // oraz w którym nie został jeszcze wystrzelony (Zabezpieczenie przed przyśpieszającym pociskiem)
        if (playerInput.AButton() && timeStamp <= Time.time)
        {
            GameObject bullet = Instantiate(bulletPrefab, rigidbody.position + Vector3.forward,rigidbody.rotation);
            timeStamp = Time.time + firingCooldown;
            Debug.Log("ISTNIEJĘ!");
        }
    }
}
