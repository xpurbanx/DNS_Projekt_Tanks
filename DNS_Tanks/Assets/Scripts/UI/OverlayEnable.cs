using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[assembly: InternalsVisibleTo("VehicleSwitch")]

public class OverlayEnable : MonoBehaviour
{
    public GameObject panel;
    public GameObject helpPanel;
    public double cooldown = 3;

    internal bool isInRadiusOfStation;

    private PlayerInputSetup playerInput;
    private double timeStamp;
    private bool isOpen = false;
    private float fadeTime = 0.25f;

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

    public void ShowHelpButtonPanel(int stationType, int vehType)
    {
        if (stationType == 1 && vehType != 1)
        {
            //helpPanel.GetComponent<Image>().color = new Color(235/255f, 35/255f, 35/255f); 
            helpPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Only jeep can use that";
        }

        else
        {
            //helpPanel.GetComponent<Image>().color = new Color32(134, 134, 134, 0);
            helpPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Press X to enter/exit";
        }

        if (!helpPanel.activeSelf)
            StartCoroutine(FadeIn(helpPanel.GetComponent<Image>()));
    }

    public void HideHelpButtonPanel()
    {
        if (helpPanel.activeSelf)
            StartCoroutine(FadeOut(helpPanel.GetComponent<Image>())); 
    }

    private YieldInstruction fadeInstruction = new YieldInstruction();
    IEnumerator FadeOut(Image image)
    {
        TextMeshProUGUI helpText = helpPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        float elapsedTime = 0.0f;
        Color c = image.color;
        Color tc = helpText.color;
        while (elapsedTime < fadeTime && c.a > 0)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            tc.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
            helpText.color = tc;
        }

        helpPanel.SetActive(false);
    }

    IEnumerator FadeIn(Image image)
    {
        helpPanel.SetActive(true);

        TextMeshProUGUI helpText = helpPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        float elapsedTime = 0.0f;
        Color c = image.color;
        Color tc = helpText.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            tc.a = Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
            helpText.color = tc;
        }
    }
}
