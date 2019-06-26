using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SupplyManager : MonoBehaviour
{
    Color color = new Color(1f, 0.5f, 0.5f);

    public int towerAmount;
    public int sniperTowerAmount;
    public int shieldedTowerAmount;
    public int obstacleAmount;

    public TextMeshProUGUI towerAmountText;
    public TextMeshProUGUI sniperTowerAmountText;
    public TextMeshProUGUI shieldedTowerAmountText;
    public TextMeshProUGUI obstacleAmountText;

    public MyButton towerButton;
    public MyButton sniperTowerButton;
    public MyButton shieldedTowerButton;
    public MyButton obstacleButton;

    void Start()
    {
        towerAmountText.text = $"Amount: {towerAmount}";
        sniperTowerAmountText.text = $"Amount: {sniperTowerAmount}";
        shieldedTowerAmountText.text = $"Amount: {shieldedTowerAmount}";
        obstacleAmountText.text = $"Amount: {obstacleAmount}";
    }

    public void DecreaseAmount(int supply)
    {
        if (supply == 0)
        {
            towerAmount -= 1;
            towerAmountText.text = $"Amount: {towerAmount}";

            if (towerAmount == 0)
            {
                towerAmountText.color = color;
                towerButton.interactable = false;
            }
        }

        if (supply == 1)
        {
            sniperTowerAmount -= 1;
            sniperTowerAmountText.text = $"Amount: {sniperTowerAmount}";

            if (sniperTowerAmount == 0)
            {
                sniperTowerAmountText.color = color;
                sniperTowerButton.interactable = false;
            }
        }

        if (supply == 2)
        {
            shieldedTowerAmount -= 1;
            shieldedTowerAmountText.text = $"Amount: {shieldedTowerAmount}";

            if (shieldedTowerAmount == 0)
            {
                shieldedTowerAmountText.color = color;
                shieldedTowerButton.interactable = false;
            }
        }

        if (supply == 3)
        {
            obstacleAmount -= 1;
            obstacleAmountText.text = $"Amount: {obstacleAmount}";

            if (obstacleAmount == 0)
            {
                obstacleAmountText.color = color;
                obstacleButton.interactable = false;
            }
        }
    }
}
