using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]
[assembly: InternalsVisibleTo("PlayerButtons")]

public class PlayerFiring : MonoBehaviour
{
    public AudioSource shot;
    public Animator animator;
    public GameObject bulletPrefab;
    public GameObject bulletOut;
    public ParticleSystem particleStart;

    // Atrybuty zarządzane przez klasę Vehicle
    internal float firingCooldown, damage, startVelocity;
    internal int playerNumber;

    private LineRenderer trajectory;
    private Vehicle vehicle;
    private PlayerInputSetup playerInput;
    private float timeStamp = 0;

    bool lineHitObstacle;

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
        particleStart = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        lineHitObstacle = false;
        if (Lock().shootingLocked == false && Lock().allLocked == false)
        {
            Fire();
            DrawTrajectory();
        }
        else
            ZeroTrajectory();

        if (timeStamp <= Time.time + 0.2)
        {
            trajectory.startColor = Color.green;
            trajectory.endColor = Color.green;
        }
        CheckLineHit();

    }

    private void Fire()
    {
        // Pocisk zostaje wystrzelony w momencie w którym dostaje input dla AButton
        // oraz w którym nie został jeszcze wystrzelony (Zabezpieczenie przed przyśpieszającym pociskiem)
        //if ((playerInput.AButton() || playerInput.Trigger() != 0) && timeStamp <= Time.time)
        if ((playerInput.LeftTrigger() != 0 || playerInput.BButton()) && timeStamp <= Time.time)
        {
            shot.Play();
            trajectory.startColor = Color.red;
            trajectory.endColor = Color.red;

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
            particleStart.Play();
            if (particleStart.isPlaying == false)
                print("nie gra");
            else
                print("gra");

        }
    }

    private void DrawTrajectory()
    {
        trajectory.positionCount = 2;
        trajectory.SetPosition(0, bulletOut.transform.position);
        trajectory.SetPosition(1, bulletOut.transform.forward * vehicle.bulletRange + transform.position);
    }

    public float GetRange()
    {
        return vehicle.bulletRange;
    }
    private void CheckLineHit()
    {
        if(trajectory)
        {
            RaycastHit hitInfo;
            if(Physics.Linecast(trajectory.GetPosition(0), trajectory.GetPosition(1), out hitInfo))
            {
                Debug.Log("Hit something: " + hitInfo.collider.gameObject);
                lineHitObstacle = true;
                trajectory.SetPosition(1, hitInfo.point);
                if((trajectory.GetPosition(1) - trajectory.GetPosition(0)).magnitude > vehicle.bulletRange)
                {
                    trajectory.SetPosition(1, bulletOut.transform.forward * vehicle.bulletRange + transform.position);
                }
            }
        }
    }

    private void ZeroTrajectory()
    {
        trajectory.positionCount = 2;
        trajectory.SetPosition(0, Vector3.zero);
        trajectory.SetPosition(1, Vector3.zero);
    }
}
