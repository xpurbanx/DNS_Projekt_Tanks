using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void OnEnable()
    {
        Destroy(transform);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
