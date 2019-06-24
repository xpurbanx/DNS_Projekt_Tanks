using TMPro;
using UnityEngine;

public class LifesManager : MonoBehaviour
{
    [Header("Ogólna ilość żyć dla każdego typu pojazdu", order = 1)]
    [Header("jeżeli chcesz customizować życia, zostaw atrybut na 0", order = 2)]
    [Space(5, order = 3)]
    public int lifes;

    public int jeepLifes1;
    public int tankLifes1;
    public int heavyTankLifes1;

    public int jeepLifes2;
    public int tankLifes2;
    public int heavyTankLifes2;

    public TextMeshProUGUI jeepAmount1;
    public TextMeshProUGUI tankAmount1;
    public TextMeshProUGUI heavyTankAmount1;

    public TextMeshProUGUI jeepAmount2;
    public TextMeshProUGUI tankAmount2;
    public TextMeshProUGUI heavyTankAmount2;

    public MyButton jeep1Button;
    public MyButton tank1Button;
    public MyButton heavyTank1Button;

    public MyButton jeep2Button;
    public MyButton tank2Button;
    public MyButton heavyTank2Button;

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

        jeepAmount1.text = $"Amount: {jeepLifes1}";
        tankAmount1.text = $"Amount: {tankLifes1}";
        heavyTankAmount1.text = $"Amount: {heavyTankLifes1}";
        jeepAmount2.text = $"Amount: {jeepLifes2}";
        tankAmount2.text = $"Amount: {tankLifes2}";
        heavyTankAmount2.text = $"Amount: {heavyTankLifes2}";
    }

    public void TankDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            tankLifes1 -= 1;
            if (tankLifes1 == 0)
            {
                tankAmount1.color = new Color(0.885f, 0.44f, 0.35f);
                tank1Button.interactable = false;
            }

            tankAmount1.text = $"Amount: {tankLifes1}";
        }

        else
        {
            tankLifes2 -= 1;
            if (tankLifes2 == 0)
            {
                tankAmount2.color = new Color(0.885f, 0.44f, 0.35f);
                tank2Button.interactable = false;
            }

            tankAmount2.text = $"Amount: {tankLifes2}";
        }

        CheckIfGameOver();
    }

    public void JeepDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            jeepLifes1 -= 1;
            if (jeepLifes1 == 0)
            {
                jeepAmount1.color = new Color(0.885f, 0.44f, 0.35f);
                jeep1Button.interactable = false;
            }

            jeepAmount1.text = $"Amount: {jeepLifes1}";
        }

        else
        {
            jeepLifes2 -= 1;
            if (jeepLifes2 == 0)
            {
                jeepAmount2.color = new Color(0.885f, 0.44f, 0.35f);
                jeep2Button.interactable = false;
            }

            jeepAmount2.text = $"Amount: {jeepLifes2}";
        }

        CheckIfGameOver();
    }

    public void HeavyTankDeath(int playerNumber)
    {
        if (playerNumber == 1)
        {
            heavyTankLifes1 -= 1;
            if (heavyTankLifes1 == 0)
            {
                heavyTankAmount1.color = new Color(0.885f, 0.44f, 0.35f);
                heavyTank1Button.interactable = false;
            }

            heavyTankAmount1.text = $"Amount: {heavyTankLifes1}";
        }

        else
        {
            heavyTankLifes2 -= 1;
            if (heavyTankLifes2 == 0)
            {
                heavyTankAmount2.color = new Color(0.885f, 0.44f, 0.35f);
                heavyTank2Button.interactable = false;
            }

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
