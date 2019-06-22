using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Tooltip("Obiekt, który zawiera w sobie particle i inne efekty")]
    public GameObject particles;

    [Tooltip("Ewentualne zmiany pozycji obiektu z efektami względem obiektu")]
    public Vector3 particlesOffset;

    [Tooltip("Minimalna siła wybuchu poszczególnych elementów")]
    public float minForce;

    [Tooltip("Maksymalna siła wybuchu poszczególnych elementów")]
    public float maxForce;

    [Tooltip("Promień wielkości wybuchu")]
    public float radius;

    [Tooltip("Czas w sekundach, po którym elementy znikają")]
    public float disappearDelay;

    public void Explode(bool enableExplosionForce, bool enablePartsDisappear)
    {
        // Jeżeli dodano obiekt z efektami
        if (particles != null)
        {
            GameObject particlesFX = Instantiate(particles, transform.position + particlesOffset, Quaternion.identity);
            Destroy(particlesFX, 5f);
        }

        foreach (Transform transform in transform)
        {
            Rigidbody rigibody = transform.GetComponent<Rigidbody>();

            // Jeżeli włączono eksplozje
            if (rigibody != null && enableExplosionForce)
            {
                rigibody.AddExplosionForce(Random.Range(minForce, maxForce), base.transform.position, radius);
            }

            // Jeżeli włączono znikanie elementów
            if (enablePartsDisappear)
            {
                Destroy(transform.gameObject, disappearDelay);
            }
        }
    }
}
