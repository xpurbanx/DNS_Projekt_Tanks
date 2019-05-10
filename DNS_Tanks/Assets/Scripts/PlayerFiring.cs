using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]

public class PlayerFiring : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletOut;

    // Atrybuty zarządzane przez klasę Vehicle
    internal float firingCooldown, damage, startVelocity;
    internal int playerNumber;

    private PlayerInputSetup playerInput;
    private float timeStamp = 0;

    void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
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
            // Tworzenie pocisku
            GameObject bullet = Instantiate(bulletPrefab, bulletOut.transform.position, bulletOut.transform.rotation);

            // Nadawanie wartości pociskowi
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.playerFiring = this;
            bulletScript.startVelocity = startVelocity;
            bulletScript.playerNumber = playerNumber;
            bulletScript.forward = bulletOut.transform.forward;
            // Nadanie obrażeń pociskowi
            /*bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().shootingObject = gameObject;*/

            // Cooldown
            timeStamp = Time.time + firingCooldown;
        }
    }
}
