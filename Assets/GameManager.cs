using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    [SerializeField]
    private int gridSize;

    private GameObject[,] grid;
    private int currentPlayer = 0;
    private int[,] board;

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
        InitializeGrid();
        ResetGame();
    }

    private void InitializeGrid()
    {
        grid = new GameObject[gridSize, gridSize];
        board = new int[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 cellPosition = new Vector3(x, 0, z);
                GameObject cell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                grid[x, z] = cell;

                Cell cellScript = cell.GetComponent<Cell>();
                cellScript.InitializeCell(x, z, this);
            }
        }
    }

    private void ResetGame()
    {
        currentPlayer = 1;

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                board[x, z] = 0;
            }
        }
    }

    public void ProcessMove(int x, int z)
    {
        if (board[x, z] != 0)
        {
            return;
        }

        board[x, z] = currentPlayer;
        GameObject cell = grid[x, z];
        cell.GetComponent<Cell>().SetCellMaterial(currentPlayer);

        if (CheckWinCondition(currentPlayer))
        {
            Debug.Log("Player " + currentPlayer + " wins!");
            // TODO Implement the win condition logic here
        }
        else if (CheckTieCondition())
        {
            Debug.Log("It's a tie!");
            // TODO Implement the tie condition logic here
        }
        else
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }
    }

    private bool CheckWinCondition(int player)
    {
        // TODO
        // Implement the win condition logic here
        // Check for horizontal, vertical, and diagonal lines, use sum of vector = grid - 1 to get forward diag, and vector parts == to eachother to get the back diag
        // Return true if the player wins, otherwise return false
        return false;
    }

    private bool CheckTieCondition()
    {
        // TODO
        // Implement the tie condition logic here
        // Return true if it's a tie, otherwise return false
        return false;
    }
}