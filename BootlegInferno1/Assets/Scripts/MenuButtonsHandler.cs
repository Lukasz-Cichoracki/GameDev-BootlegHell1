using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private LevelLoader levelLoader;
    void Start()
    {
        startButton.onClick.AddListener(StartButtonLoadLevel);
        quitButton.onClick.AddListener(QuitButtonQuitGame);
    }

    private void StartButtonLoadLevel()
    {
        levelLoader.StartCoroutine(levelLoader.LoadLevel());
    }
    private void QuitButtonQuitGame()
    {
        Application.Quit();
    }

  
}
