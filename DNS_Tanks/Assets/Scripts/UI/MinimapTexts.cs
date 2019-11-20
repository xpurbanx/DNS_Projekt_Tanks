using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapTexts : MonoBehaviour
{
    GameObject[] texts;
    GameObject[] mainMapMarkers;
    GameObject[] playerMainMarkers;
    GameObject minimap;

    void Start()
    {
        //StartCoroutine(RotateTexts());
    }

    private void Update()
    {
        texts = GameObject.FindGameObjectsWithTag("Marker");
        mainMapMarkers = GameObject.FindGameObjectsWithTag("MainMapMarkers");
        minimap = GameObject.FindGameObjectWithTag("MainMinimapCam");
        playerMainMarkers = GameObject.FindGameObjectsWithTag("PlayerMainMarkers");

        //yield return new WaitForSecondsRealtime(1 / 60);

        for (int i = 0; i <= texts.Length - 1; i++)
        {
            if (texts[i] != null && minimap != null)
                texts[i].GetComponent<Transform>().rotation = Quaternion.Euler(90f, minimap.transform.rotation.eulerAngles.y, 0f);//-1.525879e-05f, -1.525879e-05f);
        }

        for (int i = 0; i <= mainMapMarkers.Length - 1; i++)
        {
            mainMapMarkers[i].transform.localScale = new Vector3(minimap.GetComponent<Camera>().orthographicSize * 0.08481f, minimap.GetComponent<Camera>().orthographicSize * 0.08481f);
            Debug.Log(mainMapMarkers[i].transform.localScale + " <---");
        }

        for (int i = 0; i <= mainMapMarkers.Length - 1; i++)
        {
            if (mainMapMarkers[i] != null && minimap != null)
                mainMapMarkers[i].GetComponent<Transform>().rotation = Quaternion.Euler(90f, minimap.transform.rotation.eulerAngles.y, 0f);//-1.525879e-05f, -1.525879e-05f);
        }

        mainMapMarkers = GameObject.FindGameObjectsWithTag("MainMapMarkers");
        for (int i = 0; i <= mainMapMarkers.Length - 1; i++)
        {
            mainMapMarkers[i].transform.localScale = new Vector3(minimap.GetComponent<Camera>().orthographicSize * 0.08481f, minimap.GetComponent<Camera>().orthographicSize * 0.08481f, 0f);
            Debug.Log(mainMapMarkers[i].transform.localScale + " <---");
        }

        playerMainMarkers = GameObject.FindGameObjectsWithTag("PlayerMainMarkers");
        if (playerMainMarkers != null)
        {
            for (int i = 0; i <= playerMainMarkers.Length - 1; i++)
            {
                playerMainMarkers[i].transform.localScale = new Vector3(minimap.GetComponent<Camera>().orthographicSize * 0.08481f, minimap.GetComponent<Camera>().orthographicSize * 0.08481f, 0f);
                Debug.Log(playerMainMarkers[i].transform.localScale + " <---");
            }
        }



    }

    /*public IEnumerator RotateTexts()
    {


        

    }*/
}
