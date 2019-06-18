using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputSetup : MonoBehaviour
{
    private int playerNumber = 1;
    string JHorizontal;
    string JVertical;
    string JSecondaryHorizontal;

    string KHorizontal;
    string KVertical;
    string KSecondaryHorizontal; // nie ma duzego sensu, chce tylko zeby ta nazwa odpowiadala temu co jest na padzie

    string aButton;
    string bButton;
    string xButton;
    string yButton;
    string trigger;
    string leftTrigger;
    string rightTrigger;
    string leftBumper;

    string rightAnalogButton;


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
        trigger = "J" + playerNumber + "_Trigger";
        leftTrigger = "J" + playerNumber + "_LeftTrigger";
        rightTrigger = "J" + playerNumber + "_RightTrigger";
        leftBumper = "J" + playerNumber + "_LeftBumper";

        JSecondaryHorizontal = "J" + playerNumber + "_SecondaryHorizontal";
        KSecondaryHorizontal = "K" + playerNumber + "_SecondaryHorizontal";
        rightAnalogButton = "J" + playerNumber + "_RightAnalogButton";

    }
    private void Start()
    {
        setControls();
    }
    public bool AButton()
    {
        return Input.GetButton(aButton);
        //return false;
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
    public bool RightAnalogButton()
    {
        return Input.GetButton(rightAnalogButton);
    }
    public float Horizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis(JHorizontal);
        r += Input.GetAxis(KHorizontal);
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public float VerticalK()
    {
        float r = 0.0f;
        //r += Input.GetAxis(JVertical);
        r += Input.GetAxis(KVertical);
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public float SecondaryHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis(JSecondaryHorizontal);
        r += Input.GetAxis(KSecondaryHorizontal);
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public float Trigger()
    {
        float r = 0.0f;
        r += Input.GetAxis(trigger);
        // r += Input.GetAxis(KVertical);
        return Mathf.Clamp(r, -10.0f, 10.0f);
    }
    public float LeftTrigger()
    {
        float r = 0.0f;
        r += Input.GetAxis(leftTrigger);
        // r += Input.GetAxis(KVertical);
        return Mathf.Clamp(r, -10.0f, 10.0f);
    }
    public float RightTrigger()
    {
        float r = 0.0f;
        r += Input.GetAxis(rightTrigger);
        // r += Input.GetAxis(KVertical);
        return Mathf.Clamp(r, -10.0f, 10.0f);
    }

    public bool LeftBumper()
    {
        return Input.GetButton(leftBumper);
    }


}
