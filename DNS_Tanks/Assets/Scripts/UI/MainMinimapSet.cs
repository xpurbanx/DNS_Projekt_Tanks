using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMinimapSet : MonoBehaviour
{
    // FUNKCJA USTAWIAJĄCA PARAMETRY MINIMAPY DLA OKREŚLONEGO POZIOMU ORAZ MAP ROZWIJANYCH OBU GRACZY
    void SetCam(string sceneName)
    {
        GameObject[] M1, M2;
        GameObject minimap;
        Vector3 camPos = Vector3.zero;
        Vector3 camRot = Vector3.zero;
        float cameraSize = 0f;



        M1 = GameObject.FindGameObjectsWithTag("Minimap 1");
        M2 = GameObject.FindGameObjectsWithTag("Minimap 2");
        minimap = GameObject.FindGameObjectWithTag("MainMinimapCam");



        for (int i = 0; i <= M1.Length - 1; i++)
        {
            if (M1[i] != null)
                M1[i].transform.localEulerAngles = new Vector3(90f, minimap.transform.rotation.eulerAngles.y, 0f);
        }
        for (int i = 0; i <= M2.Length - 1; i++)
        {
            if (M2[i] != null)
                M2[i].transform.localEulerAngles = new Vector3(90f, minimap.transform.rotation.eulerAngles.y, 0f);
        }



        switch (sceneName)
        {
            case "Desert Battle":
                camPos = new Vector3(485f, 70.32f, 1359f);
                camRot = new Vector3(90f, 0f, 0f);
                cameraSize = 247.6f;

                transform.localPosition = camPos;
                transform.localEulerAngles = camRot;
                transform.GetComponent<Camera>().orthographicSize = cameraSize;
                return;

            case "Urantia":
                camPos = new Vector3(249f, 70.32f, 784f);
                camRot = new Vector3(90f, -90f, 0f);
                cameraSize = 165.87f;

                transform.localPosition = camPos;
                transform.localEulerAngles = camRot;
                transform.GetComponent<Camera>().orthographicSize = cameraSize;
                return;

            case "Battleground":
                camPos = new Vector3(483f, 31f, 1355f);
                camRot = new Vector3(90f, 90f, 90f);
                cameraSize = 270f;

                transform.localPosition = camPos;
                transform.localEulerAngles = camRot;
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



    // WYWOŁANIE FUNKCJI USTAWIAJĄCEJ PARAMETRY MINIMAP
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