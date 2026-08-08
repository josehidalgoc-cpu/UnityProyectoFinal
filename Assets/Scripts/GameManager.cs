using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public TextMeshProUGUI textScore;

    private void Awake()
    {
        // Si ya existe una instancia, esta es un duplicado (por recarga de escena): se destruye.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si se carga la escena del juego, es un intento nuevo: resetea el score.
        if (scene.name == "LevelOne")
        {
            ResetScore();
        }

        // El texto UI de la escena anterior se destruyó al recargar,
        // así que hay que volver a encontrarlo en la nueva escena.
        GameObject scoreTextObj = GameObject.FindGameObjectWithTag("ScoreText");
        if (scoreTextObj != null)
        {
            textScore = scoreTextObj.GetComponent<TextMeshProUGUI>();
            textScore.text = "Score: " + score.ToString();
        }
        else
        {
            textScore = null; // Evita mantener una referencia vieja en escenas sin score visible (ej. StartScene)
        }
    }

    public void AddScore()
    {
        score++;
        if (textScore != null)
        {
            textScore.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI reference is missing in GameManager.");
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}