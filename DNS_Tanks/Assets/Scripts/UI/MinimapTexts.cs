using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapTexts : MonoBehaviour
{
    GameObject[] texts;

    void Start()
    {
        StartCoroutine(RotateTexts());
    }

    public IEnumerator RotateTexts()
    {
        texts = GameObject.FindGameObjectsWithTag("Marker");

        yield return new WaitForSecondsRealtime(1 / 60);

        for (int i = 0; i <= texts.Length - 1; i++)
        {
            if (texts[i] != null)
                texts[i].GetComponent<Transform>().rotation = Quaternion.Euler(90f, -1.525879e-05f, -1.525879e-05f);
        }
    }
}
