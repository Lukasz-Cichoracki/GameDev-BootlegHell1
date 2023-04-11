using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderTriggerListener : MonoBehaviour
{
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
        PlayerTriggerDetection.Instance.OnDeath += PlayerTriggerDetection_OnDeath;
        PlayerTriggerDetection.Instance.OnNextLevel += PlayerTriggerDetection_OnNextLevel;
    }

    private void PlayerTriggerDetection_OnNextLevel(object sender, System.EventArgs e)
    {
        StartCoroutine(levelLoader.LoadLevel());
    }

    private void PlayerTriggerDetection_OnDeath(object sender, System.EventArgs e)
    {
        StartCoroutine(levelLoader.LoadLevel(SceneManager.GetActiveScene().name));
    }
}
