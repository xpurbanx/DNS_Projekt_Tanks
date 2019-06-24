using TMPro;
using UnityEngine;

public class LifesManager : MonoBehaviour
{
    [Header("Ogólna ilość żyć dla każdego typu pojazdu", order = 1)]
    [Header("jeżeli chcesz customizować życia, zostaw atrybut na 0", order = 2)]
    [Space(5, order = 3)]
    public int lifes;
    public int tankLifes1;
    public int jeepLifes1;
    public int heavyTankLifes1;
    public int tankLifes2;
    public int jeepLifes2;
    public int heavyTankLifes2;

    public TextMeshProUGUI jeepsAmount1;
    public TextMeshProUGUI tankAmount1;
    public TextMeshProUGUI heavyTankAmount1;
    public TextMeshProUGUI jeepsAmount2;
    public TextMeshProUGUI tankAmount2;
    public TextMeshProUGUI heavyTankAmount2;

    private void Start()
    {
        if (lifes != 0)
        {
            tankLifes1 = lifes;
            tankLifes2 = lifes;
            jeepLifes1 = lifes;
            jeepLifes2 = lifes;
            heavyTankLifes1 = lifes;
            heavyTankLifes2 = lifes;
        }

        jeepsAmount1.text = $"Amount: {jeepLifes1}";
        tankAmount1.text = $"Amount: {tankLifes1}";
        heavyTankAmount1.text = $"Amount: {heavyTankLifes1}";
        jeepsAmount2.text = $"Amount: {jeepLifes2}";
        tankAmount2.text = $"Amount: {tankLifes2}";
        heavyTankAmount2.text = $"Amount: {heavyTankLifes2}";
    }

    public void TankDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            tankLifes1 -= 1;
            tankAmount1.text = $"Amount: {tankLifes1}";
        }

        else
        {
            tankLifes2 -= 1;
            tankAmount2.text = $"Amount: {tankLifes2}";
        }

        CheckIfGameOver();
    }

    public void JeepDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            jeepLifes1 -= 1;
            jeepsAmount1.text = $"Amount: {jeepLifes1}";
        }

        else
        {
            jeepLifes2 -= 1;
            jeepsAmount2.text = $"Amount: {jeepLifes2}";
        }

        CheckIfGameOver();
    }

    public void HeavyTankDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            heavyTankLifes1 -= 1;
            heavyTankAmount1.text = $"Amount: {heavyTankLifes1}";
        }

        else
        {
            heavyTankLifes2 -= 1;
            heavyTankAmount2.text = $"Amount: {heavyTankLifes2}";
        }

        CheckIfGameOver();
    }

    public void CheckIfGameOver()
    {
        if (jeepLifes1 == 0 && tankLifes1 == 0 && heavyTankLifes1 == 0)
        {
            gameObject.GetComponent<WinManager>().Win(2);
        }

        if (jeepLifes2 == 0 && tankLifes2 == 0 && heavyTankLifes2 == 0)
        {
            gameObject.GetComponent<WinManager>().Win(1);
        }
    }
}
