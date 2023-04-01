using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private string levelName;

    private void Start()
    {
        Instance = this;
        levelName = SceneManager.GetActiveScene().name;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
