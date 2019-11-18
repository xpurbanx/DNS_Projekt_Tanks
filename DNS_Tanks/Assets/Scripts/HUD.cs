using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            healthBar.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = currentHealth / startHealth;
            if (currentHealth < 0) currentHealth = 0;
            healthBar.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = $"{currentHealth} / {startHealth}";
        }

        else
        {
            healthBar.transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 0;
            healthBar.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
