using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private enum AllLevels
    {
        MainMenu,
        Level1,
        Level2
    }
    
    [SerializeField] private AllLevels nextLevel;

    public event EventHandler OnLevelLoad;

    public IEnumerator LoadLevel(string levelName = null)
    {
        OnLevelLoad?.Invoke(this,EventArgs.Empty);

        yield return new WaitForSeconds(1f);

        if(string.IsNullOrEmpty(levelName))
            SceneManager.LoadScene(nextLevel.ToString());
        else
            SceneManager.LoadScene(levelName);

    }
}
