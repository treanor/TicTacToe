using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    [SerializeField]
    private Material emptyMaterial;
    [SerializeField]
    private Material mouseOverMaterial;
    [SerializeField]
    private Material player1Material;
    [SerializeField]
    private Material player2Material;

    private new Renderer renderer;
    private int Player = -1;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = emptyMaterial;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Player == -1)
        {
            Debug.Log("Clickable");
        }
    }

    private void OnMouseEnter()
    {
        if (renderer.material != emptyMaterial)
        {
            renderer.material = mouseOverMaterial;
        }
    }

    private void OnMouseExit()
    {
        if (renderer.material != mouseOverMaterial)
        {
            renderer.material = emptyMaterial;
        }
        
    }
}
