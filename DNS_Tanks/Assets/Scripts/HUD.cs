using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Vehicle currentVeh;

    public Text healthText;
    public Text speedText;

    float currentSpeed;
    float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrentVeh();
    }

    public void UpdateCurrentVeh()
    {
        currentVeh = GetComponentInChildren<Vehicle>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!currentVeh)
        {
            UpdateCurrentVeh();
            Debug.Log("UPDATED VEH IN HUD SCRIPT");
        }

        healthText.text = "Health: " + currentVeh.GetHealth();
        speedText.text = "Speed: " + currentVeh.GetSpeed();


    }
}
