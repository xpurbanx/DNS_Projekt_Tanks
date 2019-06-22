using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]
[assembly: InternalsVisibleTo("PlayerButtons")]

public class PlayerFiring : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    public GameObject bulletOut;

    // Atrybuty zarządzane przez klasę Vehicle
    internal float firingCooldown, damage, startVelocity;
    internal int playerNumber;

    private LineRenderer trajectory;
    private Vehicle vehicle;
    private PlayerInputSetup playerInput;
    private float timeStamp = 0;

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
        trajectory = bulletOut.GetComponent<LineRenderer>();
        vehicle = GetComponent<Vehicle>();
    }

    private void FixedUpdate()
    {
        if (Lock().shootingLocked == false && Lock().allLocked == false)
        {
            Fire();
            DrawTrajectory();
        }
        else
            ZeroTrajectory();

    }

    private void Fire()
    {
        // Pocisk zostaje wystrzelony w momencie w którym dostaje input dla AButton
        // oraz w którym nie został jeszcze wystrzelony (Zabezpieczenie przed przyśpieszającym pociskiem)
        //if ((playerInput.AButton() || playerInput.Trigger() != 0) && timeStamp <= Time.time)
        if ((playerInput.RightTrigger() != 0 || playerInput.AButton()) && timeStamp <= Time.time)
        {
            animator.SetTrigger("Shot");

            // Tworzenie pocisku
            GameObject bullet = Instantiate(bulletPrefab, bulletOut.transform.position, bulletOut.transform.rotation);

            // Nadawanie wartości pociskowi
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.firedBy = vehicle.vehType;
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

    private void DrawTrajectory()
    {
        trajectory.positionCount = 2;
        trajectory.SetPosition(0, bulletOut.transform.position);
        trajectory.SetPosition(1, bulletOut.transform.forward * 80 + transform.position);
    }

    private void ZeroTrajectory()
    {
        trajectory.positionCount = 0;
    }
}
