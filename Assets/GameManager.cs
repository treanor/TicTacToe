using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMarkers
{
    None,
    Player1,
    Player2
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject slotPrefab;
    [SerializeField]
    private int gridSize;
    [SerializeField]
    private Vector2[] grid;

    private Dictionary<Vector2, PlayerMarkers> myDictionary;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("GameManager if NULL");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        myDictionary = new Dictionary<Vector2, PlayerMarkers>();

        Vector2 key1 = new Vector2(1, 1);
        myDictionary.Add(key1, PlayerMarkers.None);

        Vector2 key2 = new Vector2(2, 2);
        myDictionary.Add(key2, PlayerMarkers.Player1);

        Vector2 key3 = new Vector2(3, 3);
        myDictionary.Add(key3, PlayerMarkers.Player2);

        /*        PlayerMarkers value = myDictionary[key2];
                Debug.Log("Value for key2: " + value);*/

        foreach (var item in myDictionary.Keys)
        {
            Debug.Log(item);
            PlayerMarkers value;
            myDictionary.TryGetValue(item, out value);
        }
        

        Instantiate(slotPrefab);
    }
}