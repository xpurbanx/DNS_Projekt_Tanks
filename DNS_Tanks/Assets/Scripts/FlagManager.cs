using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlagManager : MonoBehaviour
{
    public int numberOfFlags;
    public GameObject flag1;
    public GameObject flag2;
    private GameObject gameController;
    public List<GameObject> buildingsOne;
    public List<GameObject> buildingsTwo;

    private int flagsLeftOne;
    private int flagsLeftTwo;

    void Start()
    {
        flagsLeftOne = numberOfFlags;
        flagsLeftTwo = numberOfFlags;
        gameController = GameObject.FindGameObjectWithTag("GameController");

        if (numberOfFlags > buildingsOne.Count)
        {
            Debug.Log("Błąd w: FlagManager. Flag jest więcej niż budynków");
            return;
        }

        if (buildingsOne.Count == 0 || buildingsTwo.Count == 0)
        {
            Debug.Log("Błąd w: FlagManager. Nie ma przypisanych żadnych budynków");
            return;
        }

        for (int i = 0; i < numberOfFlags; i++)
        {
            int random = -1;
            bool assigned = false;

            do
            {
                random = Random.Range(0, buildingsOne.Count);
                if (!buildingsOne[random].GetComponent<Building>().hasFlag)
                {
                    Debug.Log(random);
                    buildingsOne[random].GetComponent<Building>().hasFlag = true;
                    assigned = true;
                }

            } while (!assigned);
        }

        for (int i = 0; i < numberOfFlags; i++)
        {
            int random = -1;
            bool assigned = false;

            do
            {
                random = Random.Range(0, buildingsTwo.Count);
                if (!buildingsTwo[random].GetComponent<Building>().hasFlag)
                {
                    buildingsTwo[random].GetComponent<Building>().hasFlag = true;
                    assigned = true;
                }

            } while (!assigned);
        }
    }

    public void DeleteBuildingFromArray(GameObject building)
    {   
        if (building.GetComponent<Building>().playerNumber == 1)
        {
            int index = buildingsOne.IndexOf(building);
            if (index == -1) return;
            buildingsOne.RemoveAt(index);
        }

        if (building.GetComponent<Building>().playerNumber == 2)
        {
            int index = buildingsTwo.IndexOf(building);
            if (index == -1) return;
            buildingsTwo.RemoveAt(index);
        }
    }

    public void DecreaseLeftFlagNumber(int playerNumber)
    {
        if (playerNumber == 1)
        {
            flagsLeftOne = flagsLeftOne - 1;

            if (flagsLeftOne == 0)
            {
                gameController.GetComponent<WinManager>().Win(playerNumber);
            }
        }

        if (playerNumber == 2)
        {
            flagsLeftTwo = flagsLeftTwo - 1;

            if (flagsLeftTwo == 0)
            {
                gameController.GetComponent<WinManager>().Win(playerNumber);
            }
        }
    }

    public void SpawnFlag(GameObject building)
    {
        if (building.GetComponent<Building>().playerNumber == 1)
        {
            GameObject flag = Instantiate(flag1, building.transform.position, Quaternion.identity);
            return;
        }

        if (building.GetComponent<Building>().playerNumber == 2)
        {
            GameObject flag = Instantiate(flag2, building.transform.position, Quaternion.identity);
            return;
        }
    }
}
