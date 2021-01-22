using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoSingleton<LevelLoader>
{
    public Animator transition;

    private float transitionTime = 1f;

    private void Awake()
    {
        InitSingleton();
    }

    public void LoadLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        StartCoroutine(LoadLevel(currentSceneName));
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
