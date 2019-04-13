using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[assembly: InternalsVisibleTo("Vehicle")] // Klauzula ustawiająca widoczność zmiennych internal dla klasy Vehicle

public class PlayerFiring : MonoBehaviour
{
    public static PlayerFiring instance; // Utworzenie instancji

    private PlayerInputSetup playerInput;
    public GameObject bulletPrefab;
    private Rigidbody rigidbody;
    // Opóźnienie w wystrzeliwaniu pocisku
    internal float firingCooldown = 5f;
    private float timeStamp = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        // Konstrukcja instancji
        instance = this;
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
