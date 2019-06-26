using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image healthBar;

    private Vehicle currentVeh;
    private float startHealth;

    void Start()
    {
        UpdateCurrentVeh();
        UpdateHealthBar(0);
    }

    public void UpdateCurrentVeh()
    {
        currentVeh = GetComponentInChildren<Vehicle>();

        if (currentVeh != null) startHealth = currentVeh.health;
    }

    public void UpdateHealthBar(float currentHealth)
    {
        if (!currentVeh)
        {
            UpdateCurrentVeh();
        }

        if (currentVeh != null)
        {
            healthBar.fillAmount = currentHealth / startHealth;
        }

        else
        {
            healthBar.fillAmount = 0;
        }
    }
}
