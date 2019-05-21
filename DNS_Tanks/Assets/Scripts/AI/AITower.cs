using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITower : MonoBehaviour
{
    private Building tower;
    private GameObject turret;

    public Transform target;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Building>();
        turret = GetComponentInChildren<PlayerRotateTurret>().gameObject;
        target = GameObject.FindGameObjectWithTag("Player 2 Spawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //turret.transform.LookAt(target.transform, Vector3.forward);
        Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
