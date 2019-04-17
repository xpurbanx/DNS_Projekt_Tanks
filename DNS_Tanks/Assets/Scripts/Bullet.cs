using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]
[assembly: InternalsVisibleTo("Building")]
[assembly: InternalsVisibleTo("PlayerFiring")]

public class Bullet : MonoBehaviour
{
    internal GameObject shootingObject;
    internal float startVelocity = 10f;
    //internal float damage;

    private Vehicle vehicle;
    private Building building;

    private PlayerInputSetup playerInput;
    private PlayerFiring playerFiring;

    // rigidbody - odpowiada za sam pocisk
    private new Rigidbody rigidbody;
    private bool wasIFired = false;

    void Awake()
    {
        gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Fly();
    }

    private void Update()
    {
        playerFiring = shootingObject.GetComponent<PlayerFiring>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerFiring = shootingObject.GetComponent<PlayerFiring>();
        // Jeżeli przypadkowo wykryliśmy, że kula uderzyła w obiekt, który ją wystrzelił
        if (collision.gameObject == shootingObject) return;

        // Jeżeli uderzony obiekt jest pojazdem
        if (collision.gameObject.GetComponent<Vehicle>() != null)
        {
            vehicle = collision.gameObject.GetComponent<Vehicle>();
            vehicle.hp -= playerFiring.damage;

            Destroy(gameObject);
        }

        // Jeżeli uderzony obiekt jest budynkiem
        else if (collision.gameObject.GetComponent<Building>() != null)
        {
            building = collision.gameObject.GetComponent<Building>();
            building.hp -= playerFiring.damage;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Fly()
    {
        // Pocisk porusza sie z prędkością początkową startVelocity i z każdą sekundę jego prędkość obecna maleje
        if (!wasIFired)
        {
            Vector3 movement = transform.forward * startVelocity / Time.deltaTime;
            rigidbody.AddForce(movement);
            wasIFired = true;

        }

        // Sprawdzanie czy pocisk już "Wylądował"/nie porusza się - jeżeli tak, to zniszcz
        CheckToDestroy();
    }

    private void CheckToDestroy()
    {
        // W momencie w którym pocisk nie porusza się (velocyti == [0,0,0] i został już wystrzelony
        // uznajemy go za taki, który już uderzył w inny obiekt (np. czołg)
        // można też stworzyć, aby w momencie interakcji (uderzenia) w jakąkolwiek powierzchnię pocisk był niszczony

        if (rigidbody.velocity == Vector3.zero && wasIFired == true)
            Destroy(gameObject);
    }
}