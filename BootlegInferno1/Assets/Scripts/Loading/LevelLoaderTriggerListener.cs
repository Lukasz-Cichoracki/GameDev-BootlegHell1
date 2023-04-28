using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderTriggerListener : MonoBehaviour
{
    private LevelLoader levelLoader;


    private void Start()
    {
        levelLoader = GetComponent<LevelLoader>();
        PlayerTriggerDetection.Instance.OnDeath += PlayerTriggerDetection_OnDeath;
        DevCommands.Instance.OnLevelChange += DevCommands_OnLevelChange;
        PlayerTriggerDetection.Instance.OnNextLevel += PlayerTriggerDetection_OnNextLevel;
    }

    private void DevCommands_OnLevelChange(object sender, DevCommands.OnLevelChangeEventArgs e)
    {
        if (SceneUtility.GetBuildIndexByScenePath(e.levelName) != -1)
            StartCoroutine(levelLoader.LoadLevel(e.levelName));
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
