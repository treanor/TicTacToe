using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    [SerializeField]
    private Material emptyMaterial;
    [SerializeField]
    private Material mouseOverMaterial;
    [SerializeField]
    private Material player1Material;
    [SerializeField]
    private Material player2Material;

    private int x;
    private int z;
    private GameManager gameManager;
    private new Renderer renderer;
    private int Player = -1;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = emptyMaterial;
    }

    public void InitializeCell(int x, int z, GameManager manager)
    {
        this.x = x;
        this.z = z;
        gameManager = manager;
    }

    private void OnMouseDown()
    {
        if (Player == -1)
        {
            gameManager.ProcessMove(x, z);
        }
    }

    private void OnMouseEnter()
    {
        if (renderer.material == emptyMaterial)
        {
            renderer.material = mouseOverMaterial;
        }
    }

    private void OnMouseExit()
    {
        if (renderer.material == mouseOverMaterial)
        {
            renderer.material = emptyMaterial;
        }
        
    }

    public void SetCellMaterial(int currentPlayer)
    {
        if (renderer.material != player1Material || renderer.material != player2Material)
        {
            if (currentPlayer == 1)
            {
                renderer.material = player1Material;
            }
            else if (currentPlayer == 2)
            {
                renderer.material = player2Material;
            }
        }
    }
}
