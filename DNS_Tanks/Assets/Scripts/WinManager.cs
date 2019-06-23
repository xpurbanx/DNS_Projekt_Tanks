using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public RectTransform panelGameOver;
    public Text txtGameOver;

    public bool playerOneWon;
    public bool playerTwoWon;
    public bool gameEnded;

    public void Win(int winnerNumber)
    {
        if (winnerNumber == 1) playerOneWon = true;
        if (winnerNumber == 2) playerTwoWon = true;
        gameEnded = true;

        panelGameOver.gameObject.SetActive(true);
        txtGameOver.text = $"Wygrywa gracz numer {winnerNumber}";
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panelGameOver.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
