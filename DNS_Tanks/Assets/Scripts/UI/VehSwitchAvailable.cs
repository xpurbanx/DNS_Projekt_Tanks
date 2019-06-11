using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("OverlayEnable")]

public class VehSwitchAvailable : MonoBehaviour
{
    public GameObject menu;
    public double cooldown = 3;
    private double timeStamp;
    private PlayerInputSetup playerInput;

    internal bool menuAvailable;
    internal bool closeNow;

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    public void Update()
    {
        if (playerInput.XButton() && timeStamp < Time.time && menuAvailable == true && closeNow == false)
            OpenMenu();

        if (closeNow == true)
        {
            timeStamp = Time.time + cooldown;
            if (menu != null)
            {

                Animator animator = menu.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");
                    animator.SetBool("open", false);
                }
            }
        }
    }

    public void OpenMenu()
    { 
        timeStamp = Time.time + cooldown;
        if (menu != null)
        {

            Animator animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
            }
        }
    }
}
