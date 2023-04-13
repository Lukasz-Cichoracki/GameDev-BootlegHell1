using UnityEngine;

public class LevelLoaderAnimation : MonoBehaviour
{
    private LevelLoader levelLoader;
    private Animator fade;
    private const string START = "Start";

    void Start()
    {
        levelLoader = GetComponentInParent<LevelLoader>();
        fade = GetComponent<Animator>();
        levelLoader.OnLevelLoad += LevelLoader_OnLevelLoad;
    }

    private void LevelLoader_OnLevelLoad(object sender, System.EventArgs e)
    {
        fade.SetTrigger(START);
    }
}
