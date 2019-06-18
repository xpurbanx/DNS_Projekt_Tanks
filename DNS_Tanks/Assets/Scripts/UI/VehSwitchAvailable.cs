using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("OverlayEnable")]
[assembly: InternalsVisibleTo("VehicleSwitch")]

public class VehSwitchAvailable : MonoBehaviour
{
    public GameObject menu;
    public double cooldown = 3;
    internal double timeStamp;
    private PlayerInputSetup playerInput;

    internal bool menuAvailable;
    internal bool closeNow;
    internal bool isOpen = false;

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    public void OpenMenu()
    {
        timeStamp = Time.time + cooldown;
        if (menu != null)
        {

            Animator animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                isOpen = animator.GetBool("open");
                animator.SetBool("open", true);
                isOpen = true;
            }
        }
    }

    public void CloseMenu()
    {
        timeStamp = Time.time + cooldown;
        if (menu != null)
        {

            Animator animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                isOpen = animator.GetBool("open");
                animator.SetBool("open", false);
                isOpen = false;
            }
        }
    }

    public void SwitchMenu()
    {
        timeStamp = Time.time + cooldown;
        if (menu != null)
        {

            Animator animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
                isOpen = !isOpen;
            }
        }
    }
}
