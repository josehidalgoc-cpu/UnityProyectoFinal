using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager != null)
        {
            scoreText.text = "Score: " + gameManager.score;
        }
    }
}
