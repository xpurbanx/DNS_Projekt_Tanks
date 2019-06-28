using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("Vehicle")]
[assembly: InternalsVisibleTo("Building")]
[assembly: InternalsVisibleTo("PlayerFiring")]

public class Bullet : MonoBehaviour
{
    internal PlayerFiring playerFiring;
    internal AITower towerFiring;
    internal Vector3 forward;
    internal float startVelocity = 10f;
    internal int playerNumber;
    internal int firedBy; // ID pozjazdu, który wystrzelił pocisk

    private TrailRenderer trail;

    private Vehicle vehicle;
    private Building building;
    public ParticleSystem particleEffect;
    public ParticleSystem laserParticle;
    ParticleSystem.MainModule laserMain;
    private Light light;

    // rigidbody - odpowiada za sam pocisk
    private new Rigidbody rigidbody;
    private bool wasIFired = false;

    Vector3 startPos;
    float range;
    float damage;

    void Awake()
    {

        gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rigidbody = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        particleEffect = GetComponentInChildren<ParticleSystem>();
        light = GetComponentInChildren<Light>();
        laserMain = laserParticle.main;
    }

    void Start()
    {
        if (playerFiring == null) range = towerFiring.range;
        else range = playerFiring.GetRange();
        startPos = gameObject.transform.position;
        if(playerNumber == 1)
        {
            trail.endColor = Color.blue;
            trail.startColor = Color.blue;
            light.color = Color.blue;
            laserMain.startColor = new ParticleSystem.MinMaxGradient(Color.blue);
            laserMain.startColor = Color.blue;
        }
        else if (playerNumber == 2)
        {
            trail.endColor = Color.red;
            trail.startColor = Color.red;
            light.color = Color.red;
            laserMain.startColor = new ParticleSystem.MinMaxGradient(Color.red);
            laserMain.startColor = Color.red;
        }
        else
        {
            trail.endColor = Color.yellow;
            trail.startColor = Color.yellow;
            light.color = Color.yellow;
            laserMain.startColor = new ParticleSystem.MinMaxGradient(Color.yellow);
            laserMain.startColor = Color.yellow;
        }
        if (playerFiring == null) // jeżeli nie ma playerFiring to jest to wiezyczka
        {
            damage = towerFiring.damage;
        }
        else
        {

            damage = playerFiring.damage;
        }

        // Ustawienie rozmiaru pocisku w zależności od pojazdu
        switch (firedBy)
        {
            default:
                break;
            case 1:
                Vector3 smaller = new Vector3(0.4f, 0.4f, 0.4f);
                gameObject.transform.localScale = smaller;
                break;
        }
        Fly();
        
    }

    private void FixedUpdate()
    {
       // Fly();
        CheckToDestroy();
    }

    private float DealDamage()
    {
        return damage;
    }

    private void SpawnParticles()
    {
        var particles = Instantiate(particleEffect);
        particles.transform.position = particleEffect.transform.position;
        particles.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.5f);

        if (collision.collider.gameObject.tag == "Shield")
        {
            // Destroy(gameObject, 1f);
            //collision.collider.GetComponent<AudioSource>().Play();
            return; // Shield - tag dla rzeczy od ktorych sie pocisk odbija            
        }


        // Jeżeli uderzony obiekt jest pojazdem
        if (collision.gameObject.GetComponent<Vehicle>() != null)
        {
            
            vehicle = collision.gameObject.GetComponent<Vehicle>();

            // Jeżeli wykryliśmy uderzenie w samego siebie
            if (vehicle.playerNumber == playerNumber) return;
            // Jeżeli jeep strzela z KM-u w opancerzony czołg, nie zadajemy obrażeń
            //if (firedBy == 1 && vehicle.vehicleType == 2)
               // return;
            else
                vehicle.Damage(DealDamage());

            SpawnParticles();
            Destroy(gameObject);
        }

        // Jeżeli uderzony obiekt jest budynkiem
        else if (collision.gameObject.GetComponent<Building>() != null)
        {
            
            building = collision.gameObject.GetComponent<Building>();

            if (building.playerNumber == playerNumber) return;
            building.Damage(DealDamage());
            SpawnParticles();
            Destroy(gameObject);

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
            Vector3 movement = forward * startVelocity; /// Time.deltaTime;
            //rigidbody.AddForce(movement);
            rigidbody.velocity = movement;
            wasIFired = true;
        }

        // Sprawdzanie czy pocisk już "Wylądował"/nie porusza się - jeżeli tak, to zniszcz
        //Wykomentowalem bo nie dzialalo z tym, bez tego pociski tez znikaja
        //CheckToDestroy();
    }

    private void CheckToDestroy()
    {
        // W momencie w którym pocisk nie porusza się (velocyti == [0,0,0] i został już wystrzelony
        // uznajemy go za taki, który już uderzył w inny obiekt (np. czołg)
        // można też stworzyć, aby w momencie interakcji (uderzenia) w jakąkolwiek powierzchnię pocisk był niszczony

        //if (rigidbody.velocity == Vector3.zero && wasIFired == true)
        if ((startPos - transform.position).magnitude > range)
            Destroy(gameObject);
    }
}