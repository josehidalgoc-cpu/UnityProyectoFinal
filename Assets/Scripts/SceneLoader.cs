using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        if (!string.IsNullOrEmpty(GameOverManager.levelToRetry))
        {
            SceneManager.LoadScene(GameOverManager.levelToRetry);
        }
        else
        {
            Debug.LogWarning("LoadGame: no se guardó ningún nivel, volviendo a LevelOne por defecto.");
            SceneManager.LoadScene("LevelOne");
        }
    }
}