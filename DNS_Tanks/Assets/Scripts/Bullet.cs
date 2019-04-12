using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerInputSetup playerInput;
    // rigidbody - odpowiada za sam pocisk
    private new Rigidbody rigidbody;
    // do usuwania siebie samego xD
    public GameObject gameObject;
    public float startVelocity = 10f;
    private bool wasIFired = false;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Fly();
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
            Object.Destroy(gameObject);
    }
}