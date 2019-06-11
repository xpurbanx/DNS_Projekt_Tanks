using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITower : MonoBehaviour
{

    private Transform target;
    private Vehicle targetEnemy;
    private Building building;

    [Header("General")]

    public float range = 30f;
    public float damage = 20f;
    public float startVelocity = 5f;
    [Tooltip("Added to range, tower will lock on you while in this range, but won't shoot yet")]
    public float lockonRange = 5f;


    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag1 = "Enemy";
    public string enemyTag2 = "Empire";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

    public List<GameObject> enemies;

    private bool idle = true;
    public float idleRotationSpeed = 2f;
    float shortestDistance;
    // Use this for initialization
    void Start()
    {
        
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("UpdateList", 0f, 5f); 
        building = GetComponent<Building>();
    }
    private void UpdateList()
    {
        enemies.Clear();
        enemies.AddRange(ActiveEntities.Instance.GetList(enemyTag1));
        enemies.AddRange(ActiveEntities.Instance.GetList(enemyTag2));
    }

    void UpdateTarget()
    {
        shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                UpdateList();
                return;
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                idle = false;
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range+lockonRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Vehicle>();
        }
        else
        {
            idle = true;
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (idle) RotateOnIdle();
        LockOnTarget();

        if (target != null && fireCountdown <= 0f && shortestDistance <= range)
        {
          Shoot();
          fireCountdown = 1f / fireRate;
        }

          fireCountdown -= Time.deltaTime;
       

    }

    void RotateOnIdle()
    {
        partToRotate.transform.Rotate(new Vector3(0,idleRotationSpeed,0));
    }
    void LockOnTarget()
    {
        if(target != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.towerFiring = this;
        bullet.startVelocity = startVelocity;
        bullet.playerNumber = building.playerNumber;
        bullet.forward = firePoint.transform.forward;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}