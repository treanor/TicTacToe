using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    [SerializeField]
    private int gridSize;
    [SerializeField]
    private GameObject gameOverMenu;

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
            gameOverMenu.SetActive(true);
        }
        else if (CheckTieCondition())
        {
            gameOverMenu.SetActive(true);
        }
        else
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }
    }

    public bool CheckWinCondition(int player)
    {
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
                    return false;
                }
            }
        }
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