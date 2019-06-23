using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapTexts : MonoBehaviour
{
    GameObject[] texts;

    void Start()
    {
        texts = GameObject.FindGameObjectsWithTag("Minimap Text");

        for (int i = 0; i <= texts.Length - 1; i++)
        {
            texts[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(90f, -1.525879e-05f, -1.525879e-05f);
        }
    }
}
