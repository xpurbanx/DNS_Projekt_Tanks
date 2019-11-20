using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject pauseMenuUI;
    GameObject MainMiniMap;

    private void Start()
    {
        Cursor.visible = false;
        MainMiniMap = GameObject.FindGameObjectWithTag("Main Minimap");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            if (gameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.visible = true;
        MainMiniMap.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
        MainMiniMap.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = false;
    }

    public void ChangeMap()
    {

        if (SceneManager.GetActiveScene().name == "Urantia")
        {
            SceneManager.LoadScene("Battleground");
           // Resume();
        }

        if (SceneManager.GetActiveScene().name == "Battleground")
        {
            SceneManager.LoadScene("Desert Battle");
            // Resume();
        }

        if (SceneManager.GetActiveScene().name == "Desert Battle")
        {
            SceneManager.LoadScene("Urantia");
            //Resume();
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
