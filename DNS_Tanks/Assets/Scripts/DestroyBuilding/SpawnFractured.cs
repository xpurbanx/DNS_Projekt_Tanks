using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFractured : MonoBehaviour
{
    [Tooltip("Model zniszczonego budynku")]
    public GameObject fracturedObject;

    [Tooltip("Czy budynek ma wybuchnąć")]
    public bool enableExplosionForce;

    [Tooltip("Czy zniszczony obiekt budynku ma zniknąć po jakimś czasie")]
    public bool enablePartsDisappear;

    private void OnMouseDown()
    {
        SpawnFracturedObject();
    }

    public void SpawnFracturedObject()
    {
        // Zamiana aktualnego obiektu budynku, na obiekt zniszczonego budynku
        GameObject fractObj = Instantiate(fracturedObject, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), transform.rotation);
        Destroy(gameObject);

        // Funkcja odpowiedzialna za ewentualną eksplozję i zniknięcie zniszczonych elementów budynku
        fractObj.GetComponent<Explosion>().Explode(enableExplosionForce, enablePartsDisappear);
    }
}
