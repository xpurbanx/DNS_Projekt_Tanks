using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOverlay : MonoBehaviour
{
    // Start is called before the first frame update
    //private PlayerInputSetup playerInput;
    private string buttonName;
    public double cooldown = 3f;
    private double cooldownTime = 0;
    public GameObject panel;
    void Start()
    {
        //playerInput = GetComponent<PlayerInputSetup>();
        if (gameObject.tag == "Player 1")
            buttonName = "J1X_Button";
        else
            buttonName = "J2X_Button";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OpenPanel();
    }

    public void OpenPanel()
    {
        if (Input.GetButton(buttonName) && Time.time >= cooldownTime)
        {            
            if (panel != null)
            {
                Animator animator = panel.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");
                    animator.SetBool("open", !isOpen);
                }
            }
            cooldownTime = Time.time + cooldown;
        }
            

    }
}
