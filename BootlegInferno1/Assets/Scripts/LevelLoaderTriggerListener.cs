using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderTriggerListener : MonoBehaviour
{
    [SerializeField] private PlayerTriggerDetection playerTriggerDetection;
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
        playerTriggerDetection.OnDeath += PlayerTriggerDetection_OnDeath;
    }

    private void PlayerTriggerDetection_OnDeath(object sender, System.EventArgs e)
    {
        StartCoroutine(levelLoader.LoadLevel(SceneManager.GetActiveScene().name));
    }
}
