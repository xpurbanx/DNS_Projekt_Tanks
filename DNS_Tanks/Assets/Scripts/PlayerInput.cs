using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Tooltip("Numer gracza. Przykład: gracz 1 będzie kierował klawiszami z dopiskiem 1 (sprawdź Project Settings -> Input)")]
    public int playerNumber = 1;

    private string kVertical;
    private string kHorizontal;
    private string jVertical;
    private string jHorizontal;

    void Start()
    {
        SetControls();
    }

    void SetControls()
    {
        kVertical = "KVertical" + playerNumber;
        kHorizontal = "KHorizontal" + playerNumber;
        jVertical = "JVertical" + playerNumber;
        jHorizontal = "JHorizontal" + playerNumber;
    }

    public float Vertical()
    {
        float verticalValue = Input.GetAxis(kVertical);
        verticalValue += Input.GetAxis(jVertical);
        return verticalValue;
    }

    public float Horizontal()
    {
        float horizontalValue = Input.GetAxis(kHorizontal);
        horizontalValue += Input.GetAxis(jHorizontal);
        return horizontalValue;
    }
}
