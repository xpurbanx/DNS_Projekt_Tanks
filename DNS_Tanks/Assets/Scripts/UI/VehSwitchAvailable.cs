﻿using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("OverlayEnable")]
[assembly: InternalsVisibleTo("VehicleSwitch")]

public class VehSwitchAvailable : MonoBehaviour
{
    public GameObject menu;
    public MyButton defaultButton;
    public double cooldown = 3;

    internal double timeStamp;
    internal bool menuAvailable;
    internal bool closeNow;
    internal bool isOpen = false;

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
                defaultButton.Select();
                Lock().aimingLocked = true;
                Lock().mapLocked = true;
                Lock().movementLocked = true;
                Lock().shootingLOCKED = true;
                Lock().shootingLocked = true;
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
                Lock().shootingLocked = false;
                Lock().mapLocked = false;
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
                defaultButton.Select();
                Lock().mapLocked = !Lock().mapLocked;
                Lock().aimingLocked = !Lock().aimingLocked;
                Lock().movementLocked = !Lock().movementLocked;
                Lock().shootingLOCKED = !Lock().shootingLOCKED;
                Lock().shootingLocked = !Lock().shootingLocked;
            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            StartCoroutine(SelectDefault());
        }
    }

    private IEnumerator SelectDefault()
    {
        yield return new WaitForSeconds(0.1f);
        defaultButton.Select();
    }
}
