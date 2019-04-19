using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSetup : MonoBehaviour
{
    private int playerNumber = 1;
    string JHorizontal;
    string JVertical;

    string KHorizontal;
    string KVertical;

    string aButton;
    string bButton;
    string xButton;
    string yButton;

    string triggers;

    protected void setControls()
    {
        if (gameObject.tag == "Player 2") playerNumber = 2;
        else playerNumber = 1;

        JHorizontal = "J" + playerNumber + "Horizontal";
        JVertical = "J" + playerNumber + "Vertical";

        KHorizontal = "K" + playerNumber + "Horizontal";
        KVertical = "K" + playerNumber + "Vertical";

        aButton = "J" + playerNumber + "A_Button";
        bButton = "J" + playerNumber + "B_Button";
        xButton = "J" + playerNumber + "X_Button";
        yButton = "J" + playerNumber + "Y_Button";

        triggers = "J" + playerNumber + "Triggers";
    }
    private void Start()
    {
        setControls();
    }
    public bool AButton()
    {
        return Input.GetButton(aButton);
    }
    public bool BButton()
    {
        return Input.GetButton(bButton);
    }
    public bool XButton()
    {
        return Input.GetButton(xButton);
    }
    public bool YButton()
    {
        return Input.GetButton(yButton);
    }
    public int Triggers()
    {
        float value = Input.GetAxis(triggers);

        if (value == 1)
        {
            return 1;
        }

        else if (value == -1)
        {
            return -1;
        }

        else
        {
            return 0;
        }
    }
    public float Horizontal()
    {
        float horizontalValue = 0.0f;
        horizontalValue += Input.GetAxis(JHorizontal);
        horizontalValue += Input.GetAxis(KHorizontal);
        return Mathf.Clamp(horizontalValue, -1.0f, 1.0f);
    }
    public float Vertical()
    {
        float verticalValue = 0.0f;
        verticalValue += Input.GetAxis(JVertical);
        verticalValue += Input.GetAxis(KVertical);
        return Mathf.Clamp(verticalValue, -1.0f, 1.0f);
    }
}
