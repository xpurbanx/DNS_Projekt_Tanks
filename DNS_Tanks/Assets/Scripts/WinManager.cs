using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public RectTransform panelGameOver;
    public Text txtGameOver;

    public void Win(int winnerNumber)
    {
        panelGameOver.gameObject.SetActive(true);
        txtGameOver.text = $"Wygrywa gracz numer {winnerNumber}";
        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panelGameOver.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
