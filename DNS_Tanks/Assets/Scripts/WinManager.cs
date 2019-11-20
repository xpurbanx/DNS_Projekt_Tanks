using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public RectTransform panelGameOver;
    public Text txtGameOver;
    string color;

    public bool playerOneWon;
    public bool playerTwoWon;
    public bool gameEnded;

    public void Win(int winnerNumber)
    {
        if (winnerNumber == 1)
        {
            playerOneWon = true;
            color = "BLUE";
        }

        //txtGameOver.text = "Player BLUE has won!";
        if (winnerNumber == 2)
        {
            playerTwoWon = true;
            color = "RED";
        }

        gameEnded = true;

        panelGameOver.gameObject.SetActive(true);
        txtGameOver.text = $"Player {color} has won!";
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
