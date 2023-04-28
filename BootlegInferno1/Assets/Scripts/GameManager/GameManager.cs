using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private Transform devMenu;
    private bool isActive=false;

    public bool IsPaused { get; private set; }

    [SerializeField] private Button submitButton;

    private void Start()
    {
        Instance = this;
        submitButton.onClick.AddListener(PauseGame);
        submitButton.onClick.AddListener(ShowHideDevMenu);
        devMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Insert))
        {
            ShowHideDevMenu();
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if(!IsPaused)
        {
            Time.timeScale = 0f;
            IsPaused = true;
            return;
        }
            Time.timeScale = 1f;
            IsPaused = false;
        
    }

    private void ShowHideDevMenu()
    {
        isActive = !isActive;
        devMenu.gameObject.SetActive(isActive);
    }
}
