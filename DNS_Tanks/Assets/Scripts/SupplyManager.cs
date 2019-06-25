using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SupplyManager : MonoBehaviour
{
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
                towerAmountText.color = new Color(0.885f, 0.44f, 0.35f);
                towerButton.interactable = false;
                towerButton.Select();
            }
        }

        if (supply == 1)
        {
            sniperTowerAmount -= 1;
            sniperTowerAmountText.text = $"Amount: {sniperTowerAmount}";

            if (sniperTowerAmount == 0)
            {
                sniperTowerAmountText.color = new Color(0.885f, 0.44f, 0.35f);
                sniperTowerButton.interactable = false;
                sniperTowerButton.Select();
            }
        }

        if (supply == 2)
        {
            shieldedTowerAmount -= 1;
            shieldedTowerAmountText.text = $"Amount: {shieldedTowerAmount}";

            if (shieldedTowerAmount == 0)
            {
                shieldedTowerAmountText.color = new Color(0.885f, 0.44f, 0.35f);
                shieldedTowerButton.interactable = false;
                shieldedTowerButton.Select();
            }
        }

        if (supply == 3)
        {
            obstacleAmount -= 1;
            obstacleAmountText.text = $"Amount: {obstacleAmount}";

            if (obstacleAmount == 0)
            {
                obstacleAmountText.color = new Color(0.885f, 0.44f, 0.35f);
                obstacleButton.interactable = false;
                obstacleButton.Select();
            }
        }
    }
}
