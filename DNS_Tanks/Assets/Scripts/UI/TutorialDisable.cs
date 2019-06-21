using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDisable : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.SetActive(false);
            Debug.Log("Wyłączono tutorial");
        }
           

    }
}
