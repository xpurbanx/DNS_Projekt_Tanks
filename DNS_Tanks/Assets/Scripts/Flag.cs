using System.Runtime.CompilerServices;
using UnityEngine;
[assembly: InternalsVisibleTo("PlayerFlagManager")]

public class Flag : MonoBehaviour
{
    [Header("Numer flagi, odpowiada numerowi gracza, do którego należy flaga:")]
    public int flagNumber = 0;

    internal bool isTaken = false;

    private float speed = 3f;
    private float height = 0.009f;

    private void OnTriggerEnter(Collider other)
    {
        // Pierwsze 7 znaków tagu. Np. z Player 1 będzie to Player
        if (other.gameObject.tag.Length < 7) return;
        string shortTag = other.gameObject.tag.Substring(0, 7);

        // Jeżeli z flagą koliduje obiekt o tagu Player (...)
        if (shortTag == "Player ")
        {
            // Pobieramy numer gracza za pomocą tagu (ostatnia cyfra)
            // Pobieramy gameobject Tank tego gracza, dość brzydko bo za pomocą GameObject Find, ale nie mogłem wpaść na inny pomysł
           // string playerNumberString = other.gameObject.tag.Substring(other.gameObject.tag.Length - 1);
            string playerNumberString = other.gameObject.tag.Substring(other.gameObject.tag.Length - 1);
            int playerNumber = Utility.ParseToInt(playerNumberString);

            // trzeba zmienic zeby dzialalo dla innych pojazdow
            // GameObject player = GameObject.Find("Tank Variant " + playerNumberString);
            GameObject player = GameObject.Find("Vehicle " + playerNumberString);

            // Jeżeli czołg, z którym kolidujemy nie jest właścicielem tej flagi (czołg nie może nieść swojej flagi)*
            // I jeżeli czołg, z którym kolidujemy nie posiada już flagi (nie może przecież nieść dwóch na raz)
            // *Możemy to jeszcze zmienić
            if (flagNumber != playerNumber && player.GetComponent<PlayerFlagManager>().CheckFlag() == false)
            {
                // Czołg bierze flagę
                PickUpFlag(player);
            }
        }
    }

    private void Update()
    {
        // Skrypt odpowiadający za lewitowanie flagi
        if (!isTaken)
        {
            Vector3 position = transform.position;
            float newY = Mathf.Sin(Time.time * speed) * height + position.y;
            transform.position = new Vector3(position.x, newY, position.z);
        }
    }

    private void PickUpFlag(GameObject player)
    {
        // Zaznaczamy w Eq czołgu, że nosi on aktualnie flagę
        player.GetComponent<PlayerFlagManager>().PickFlag();

        Destroy(gameObject);
    }
}
