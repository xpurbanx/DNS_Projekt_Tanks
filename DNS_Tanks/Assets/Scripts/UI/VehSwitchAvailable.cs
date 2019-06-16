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
    internal bool isOpen;

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    Animator animator;

    public void Update()
    {
        animator = menu.GetComponent<Animator>();
        Debug.Log("Menu: "+menu+", ANIMATOR: "+animator+", isOpen: "+isOpen+", animator.GetBool(\"open\"): "+animator.GetBool("open"));

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
                    isOpen = animator.GetBool("open");
                    animator.SetBool("open", false);
                    isOpen = false;
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
                isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
                isOpen = !isOpen;
            }
        }
    }
}
