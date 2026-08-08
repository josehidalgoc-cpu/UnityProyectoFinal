using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Guarda el nombre del nivel donde murió el jugador, para poder reintentarlo.
    // Es estática porque tiene que sobrevivir el cambio a DeathScene.
    public static string levelToRetry;

    void Start()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
        {
            scoreText.text = "Score: " + gameManager.score;
        }
    }
}