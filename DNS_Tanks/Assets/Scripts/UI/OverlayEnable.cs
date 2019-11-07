using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("VehicleSwitch")]

public class OverlayEnable : MonoBehaviour
{
    public GameObject panel;
    public double cooldown = 3;

    internal bool isInRadiusOfStation;

    private PlayerInputSetup playerInput;
    private double timeStamp;
    private bool isOpen = false;

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
        if (playerInput.XButton() && timeStamp < Time.time && Lock().mapLocked == false && Lock().allLocked == false && MenuPause.gameIsPaused == false)
        {
            // Jeśli gracz nie jest w zasięgu jakiejś stacji, mapa się przełączy
            if (isInRadiusOfStation == false)
                SwitchPanel();

            // Jeśli jest, mapa się tylko wyłączy
            else
                ClosePanel();
        }
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
                Lock().shootingLocked = !Lock().shootingLocked;
                Lock().menusLocked = !Lock().menusLocked;
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
                isOpen = true;
                Lock().shootingLocked = true;
                Lock().menusLocked = true;
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
                isOpen = false;
                Lock().shootingLocked = false;
                Lock().menusLocked = false;
            }
        }
    }
}
