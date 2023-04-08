using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

   
    private enum AllLevels
    {
        MainMenu,
        Level1
    }
    
    [SerializeField] private AllLevels nextLevel;
    private AllLevels mainMenu = AllLevels.MainMenu;


    [SerializeField] private Animator fade;
    private const string TRIGGER_NAME = "Start";


    private void Update()
    {
        if(SceneManager.GetActiveScene().name==mainMenu.ToString() && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadLevel(nextLevel.ToString()));
        }
    }


    private void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(mainMenu.ToString()));
    }

    public IEnumerator LoadLevel(string levelName)
    {
        fade.SetTrigger(TRIGGER_NAME);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelName);

    }
}
