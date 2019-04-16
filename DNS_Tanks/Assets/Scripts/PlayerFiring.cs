using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    private PlayerInputSetup playerInput;
    public GameObject bulletPrefab;
    public GameObject bulletOut;
    // Opóźnienie w wystrzeliwaniu pocisku, zarządzane też przez klasę Vehicle
    public float firingCooldown = 1f;
    private float timeStamp = 0;

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
            GameObject bullet = Instantiate(bulletPrefab, bulletOut.transform.position, bulletOut.transform.rotation);
            timeStamp = Time.time + firingCooldown;
        }
    }
}
