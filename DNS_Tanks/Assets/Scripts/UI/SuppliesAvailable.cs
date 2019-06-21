using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("OverlayEnable")]
[assembly: InternalsVisibleTo("SupplyStation")]

public class SuppliesAvailable : MonoBehaviour
{
    public GameObject menu;
    public List<GameObject> prefabs;
    public double cooldown = 3;
    internal double timeStamp;
    private PlayerInputSetup playerInput;

    internal bool canBeSet = false;
    internal bool hasSupply = false;
    internal bool menuAvailable;
    internal bool closeNow;
    internal bool isOpen = false;

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    public void OpenMenu()
    {
        if (gameObject.GetComponentInParent<Respawn>().CurrentVeh().GetComponent<Vehicle>().vehType == 1)
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
                }
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
            }
        }
    }

    public void SwitchMenu()
    {
        if (gameObject.GetComponentInParent<Respawn>().CurrentVeh().GetComponent<Vehicle>().vehType == 1)
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
                }
            }
        }

    }
}
