using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public static PlayerFiring instance; // Utworzenie instancji

    //private Rigidbody turret;
=======
>>>>>>> parent of 9f9fae0... Modyfikowanie atryb. osobnych skryptów z poziomu klasy
=======
>>>>>>> parent of 9f9fae0... Modyfikowanie atryb. osobnych skryptów z poziomu klasy
=======
>>>>>>> parent of 9f9fae0... Modyfikowanie atryb. osobnych skryptów z poziomu klasy
    private PlayerInputSetup playerInput;
    public GameObject bulletPrefab;
    private Rigidbody rigidbody;
    // Rodzaj amunicji, prowadzonego ognia
    internal int fireType;
    // Opóźnienie w wystrzeliwaniu pocisku
    public float firingCooldown = 5f;
    private float timeStamp = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        //turret = GetComponent<Rigidbody>();
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
            GameObject bullet = Instantiate(bulletPrefab, rigidbody.position + Vector3.forward, rigidbody.rotation);
            timeStamp = Time.time + firingCooldown;
            Debug.Log("ISTNIEJĘ!");
        }

    }
}
