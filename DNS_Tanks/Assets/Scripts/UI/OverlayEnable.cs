using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayEnable : MonoBehaviour
{
    public GameObject panel;
    public double cooldown = 3;
    private double timeStamp;
    private PlayerInputSetup playerInput;
    bool isOpen = false;

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    private LockActions Lock()
    {
        LockActions lockActions = GetComponentInParent<LockActions>();
        return lockActions;
    }

    public void Update()
    {
        if (playerInput.BButton() && timeStamp < Time.time && Lock().menusLocked == false && Lock().mapLocked == false && Lock().allLocked == false)
            SwitchPanel();
    }

    public void SwitchPanel()
    {
        timeStamp = Time.time + cooldown;
        if (panel != null)
        {

            Animator animator = panel.GetComponent<Animator>();
            if (animator != null)
            {

                isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
                Debug.Log(isOpen + " Halo");
                isOpen = !isOpen;
                if (isOpen == true)
                    Lock().shootingLocked = true;
                else
                    Lock().shootingLocked = false;
            }
        }
    }

    public void OpenPanel()
    {
        timeStamp = Time.time + cooldown;
        if (panel != null)
        {

            Animator animator = panel.GetComponent<Animator>();
            if (animator != null)
            {

                isOpen = animator.GetBool("open");
                animator.SetBool("open", true);
                Debug.Log(isOpen + " Halo");
                Lock().shootingLocked = true;
            }
        }
    }

    public void ClosePanel()
    {
        timeStamp = Time.time + cooldown;
        if (panel != null)
        {

            Animator animator = panel.GetComponent<Animator>();
            if (animator != null)
            {

                isOpen = animator.GetBool("open");
                animator.SetBool("open", false);
                Debug.Log(isOpen + " Halo");
                Lock().shootingLocked = false;
            }
        }
    }
}
