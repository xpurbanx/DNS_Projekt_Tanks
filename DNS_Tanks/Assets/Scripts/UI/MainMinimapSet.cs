using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMinimapSet : MonoBehaviour
{
    // FUNKCJA USTAWIAJĄCA PARAMETRY MINIMAPY DLA OKREŚLONEGO POZIOMU
    void SetCam(string sceneName)
    {
        Vector3 camPos = Vector3.zero;
        float cameraSize = 0f;
        switch (sceneName)
        {
            case "Desert Battle":
                camPos = new Vector3(485f, 70.32f, 1359f);
                cameraSize = 227.6f;

                transform.localPosition = camPos;
                transform.GetComponent<Camera>().orthographicSize = cameraSize;
                return;

            case "Urantia":
                camPos = new Vector3(485f, 70.32f, 1359f);
                cameraSize = 227.6f;

                transform.localPosition = camPos;
                transform.GetComponent<Camera>().orthographicSize = cameraSize;
                return;

            default:
                return;
        }
    }



    // ROZPOCZĘCIE ŚLEDZENIA WCZYTYWANYCH POZIOMÓW
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }



    // WYWOŁANIE FUNKCJI USTAWIAJĄCEJ PARAMETRY MINIMAPY 
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetCam(scene.name);
    }



    // ZAKOŃCZENIE ŚLEDZENIA WCZYTYWANYCH POZIOMÓW
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
}