using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayEnable : MonoBehaviour
{
    public GameObject panel;
    public double cooldown = 3;
    private double timeStamp;
    private PlayerInputSetup playerInput;

    public void Start()
    {
        playerInput = GetComponentInParent<PlayerInputSetup>();
    }

    public void Update()
    {

        if (playerInput.BButton() && timeStamp < Time.time)
            OpenPanel();            
            
    }

    public void OpenPanel()
    {
        timeStamp = Time.time + cooldown;
        if (panel != null)
        {
            
            Animator animator = panel.GetComponent<Animator>();
            if (animator != null)
            {
                
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
                Debug.Log(isOpen + " Halo");
                
            }
        }
    }


}
