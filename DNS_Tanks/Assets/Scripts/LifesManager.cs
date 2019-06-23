using UnityEngine;

public class LifesManager : MonoBehaviour
{
    [Header("Ogólna ilość żyć dla każdego typu pojazdu", order = 1)]
    [Header("jeżeli chcesz customizować życia, zostaw atrybut na 0", order = 2)]
    [Space(5, order = 3)]
    public int lifes;
    public int tankLifes1;
    public int jeepLifes1;
    public int tankLifes2;
    public int jeepLifes2;

    private void Start()
    {
        if (lifes != 0)
        {
            tankLifes1 = lifes;
            tankLifes2 = lifes;
            jeepLifes1 = lifes;
            jeepLifes2 = lifes;
        }
    }

    public void TankDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            tankLifes1 -= 1;
        }

        else
        {
            tankLifes2 -= 1;
        }

        CheckIfGameOver();
    }

    public void JeepDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            jeepLifes1 -= 1;
        }

        else
        {
            jeepLifes2 -= 1;
        }

        CheckIfGameOver();
    }

    public void CheckIfGameOver()
    {
        if (jeepLifes1 == 0 && tankLifes1 == 0)
        {
            gameObject.GetComponent<WinManager>().Win(2);
        }

        if (jeepLifes2 == 0 && tankLifes2 == 0)
        {
            gameObject.GetComponent<WinManager>().Win(1);
        }
    }
}
