using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    int i = 0;
    public int playerNumber;
    GameObject[] withPlayerTag;
    GameObject player; // jeep/tank prefab

    void Start()
    {

    }

    void LateUpdate()
    {
        SetUp();
        if (player != null)
        {
            Vector3 newPos = player.transform.position;
            newPos.y = transform.position.y;
            transform.position = newPos;

            //transform.rotation = Quaternion.Euler(90f, player.transform.eulerAngles.y, 0f); wykomentowałem obrót razem z graczem
        }

    }

    void SetUp()
    {
        withPlayerTag = GameObject.FindGameObjectsWithTag("Player " + playerNumber);
        for (i = 0; i <= withPlayerTag.Length - 1; i++)
        {
            if (withPlayerTag[i].GetComponent<PlayerFiring>() && withPlayerTag[i].tag == "Player " + playerNumber)
                player = withPlayerTag[i];
        }
    }
}
