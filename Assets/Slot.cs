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



    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = emptyMaterial;
    }

    void Update()
    {
        
    }

    private void OnMouseDown(object sender)
    {
        Debug.Log("Clicked");
/*        Cube cube = sender as Cube;
        if (cube != null)
        {
            cube.material = (currentPlayer == 1) ? player1Material : player2Material;
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        }*/
    }

    private void OnMouseEnter()
    {
        // Change the material to the highlight material when the mouse enters the object
        renderer.material = mouseOverMaterial;
    }

    private void OnMouseExit()
    {
        // Change the material back to the normal material when the mouse exits the object
        renderer.material = emptyMaterial;
    }
}
