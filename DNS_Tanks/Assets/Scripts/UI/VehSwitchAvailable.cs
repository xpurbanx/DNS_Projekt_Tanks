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

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    public void OpenMenu()
    {
        timeStamp = Time.time + cooldown;
        if (menu != null && Lock().menusLocked == false && Lock().allLocked == false)
        {

            Animator animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                isOpen = animator.GetBool("open");
                animator.SetBool("open", true);
                isOpen = true;
                Lock().aimingLocked = true;
                Lock().movementLocked = true;
                Lock().shootingLOCKED = true;
            }
        }
    }

    public void CloseMenu()
    {
        timeStamp = Time.time + cooldown;
        if (menu != null && Lock().menusLocked == false && Lock().allLocked == false)
        {

            Animator animator = menu.GetComponent<Animator>();
            if (animator != null)
            {
                isOpen = animator.GetBool("open");
                animator.SetBool("open", false);
                isOpen = false;
                Lock().aimingLocked = false;
                Lock().movementLocked = false;
                Lock().shootingLOCKED = false;
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
                isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
                isOpen = !isOpen;
                Lock().aimingLocked = !Lock().aimingLocked;
                Lock().movementLocked = !Lock().movementLocked;
                Lock().shootingLOCKED = !Lock().shootingLOCKED;
            }
        }
    }
    private void Update()
    {
        Debug.Log(Lock().movementLocked);
    }
}
