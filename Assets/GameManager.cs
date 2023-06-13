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

                Cell cellScript = grid[x, z].GetComponent<Cell>();
                cellScript.ResetCell();
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
            ResetGame();
        }
        else if (CheckTieCondition())
        {
            Debug.Log("It's a tie!");
            // TODO Implement the tie condition logic here
            ResetGame();
        }
        else
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }
    }

    public bool CheckWinCondition(int player)
    {
        // Check rows
        for (int i = 0; i < gridSize; i++)
        {
            bool hasWon = true;
            for (int j = 0; j < gridSize; j++)
            {
                if (board[i, j] != player)
                {
                    hasWon = false;
                    break;
                }
            }

            if (hasWon)
            {
                return true;
            }
        }

        // Check columns
        for (int j = 0; j < gridSize; j++)
        {
            bool hasWon = true;
            for (int i = 0; i < gridSize; i++)
            {
                if (board[i, j] != player)
                {
                    hasWon = false;
                    break;
                }
            }

            if (hasWon)
            {
                return true;
            }
        }

        // Check diagonals
        bool diagonal1 = true;
        bool diagonal2 = true;

        for (int i = 0; i < gridSize; i++)
        {
            if (board[i, i] != player)
            {
                diagonal1 = false;
            }

            if (board[i, gridSize - 1 - i] != player)
            {
                diagonal2 = false;
            }
        }

        if (diagonal1 || diagonal2)
        {
            return true;
        }

        // No winning condition found
        return false;
    }


    public bool CheckTieCondition()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                if (board[x, y] == 0)
                {
                    // If any empty cell is found, the game is not a tie
                    return false;
                }
            }
        }

        // If all cells are filled and no win condition is met, it's a tie
        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetGame();
        }
        
    }
}