using TMPro;
using UnityEngine;

public class WinnerText : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        UpdatePlayerText();
    }

    private void Update()
    {
        if (gameManager != null && textMeshPro != null)
        {
            UpdatePlayerText();
        }
    }

    private void UpdatePlayerText()
    {
        int currentPlayer = gameManager.currentPlayer;
        textMeshPro.text = "Player " + currentPlayer + " Wins!";
    }
}
