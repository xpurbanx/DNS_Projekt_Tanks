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
<<<<<<< HEAD
    internal bool isOpen = false;
=======
>>>>>>> parent of 3a6fbeb... Request #48 (Mix zmian Michała, Mikołaja i moich, rozwiązane konflikty i naprawione małe bugi)

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    private LockActions Lock()
    {
<<<<<<< HEAD
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    public void OpenMenu()
    {
        timeStamp = Time.time + cooldown;
        if (menu != null && Lock().menusLocked == false && Lock().allLocked == false)
=======
        if (playerInput.XButton() && timeStamp < Time.time && menuAvailable == true && closeNow == false)
            OpenMenu();
        if(closeNow == true)
>>>>>>> parent of 3a6fbeb... Request #48 (Mix zmian Michała, Mikołaja i moich, rozwiązane konflikty i naprawione małe bugi)
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
        if (menu != null && Lock().menusLocked == false && Lock().allLocked == false)
        {

<<<<<<< HEAD
            Animator animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                isOpen = animator.GetBool("open");
                animator.SetBool("open", false);
                isOpen = false;
=======
                Animator animator = menu.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("open");
                    animator.SetBool("open", false);
                }
>>>>>>> parent of 3a6fbeb... Request #48 (Mix zmian Michała, Mikołaja i moich, rozwiązane konflikty i naprawione małe bugi)
            }
        }
    }

    public void SwitchMenu()
    {
        timeStamp = Time.time + cooldown;
        if (menu != null && Lock().menusLocked == false && Lock().allLocked == false)
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
