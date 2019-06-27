using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEntities : MonoBehaviour
{
    public static ActiveEntities Instance;

    public List<GameObject> player1Entities;
    public List<GameObject> player2Entities;
    public List<GameObject> empireEntities;

    [SerializeField]
    string player1Tag;
    [SerializeField]
    string player2Tag;
    [SerializeField]
    string empireTag;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
            GameObject.Destroy(Instance);
        else
            Instance = this;

        //DontDestroyOnLoad(this);

        player1Entities = new List<GameObject>();
        player2Entities = new List<GameObject>();
        empireEntities = new List<GameObject>();

        
    }
    public void AddToList(string tag, GameObject entity)
    {
        if (tag == player1Tag) player1Entities.Add(entity);
        else if(tag == player2Tag) player2Entities.Add(entity);
        else if(tag == empireTag) empireEntities.Add(entity);
    }
    public void RemoveFromList(string tag, GameObject entity)
    {
        if (tag == player1Tag) player1Entities.Remove(entity);
        else if (tag == player2Tag) player2Entities.Remove(entity);
        else if (tag == empireTag) empireEntities.Remove(entity);
    }

    public List<GameObject> GetList(string tag)
    {
        if (tag == player1Tag) return player1Entities;
        else if (tag == player2Tag) return player2Entities;
        else if (tag == empireTag) return empireEntities;
        else return null;
    }
}
