using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[assembly: InternalsVisibleTo("OverlayEnable")]

public class SuppliesAvailable : MonoBehaviour
{
    public List<GameObject> supplies;
    public List<GameObject> prefabs;
    public GameObject menu;
    public double cooldown = 3;
    private double timeStamp;
    private PlayerInputSetup playerInput;

    internal bool menuAvailable;
    internal bool closeNow;
    internal bool isOpen;
    int t;

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    public void Update()
    {
        CheckForOpen();
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

    public void CheckForOpen()
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
                    isOpen = animator.GetBool("open");
                    animator.SetBool("open", false);
                    isOpen = false;
                }
            }
        }
    }
}
