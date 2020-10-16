using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadStart()
    {
        LoadSceneWithDelay("Main", 0.5f);
    }

    public void LoadGame()
    {
        LoadSceneWithDelay("Game", 0.5f);
    }

    private void Start()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void LoadSceneWithDelay(string sceneName, float timeBetweenScenes)
    {
        StartCoroutine(delayLoad(sceneName, timeBetweenScenes));
    }

    private IEnumerator delayLoad(string sceneName, float timeBetweenScenes)
    {
        yield return new WaitForSeconds(timeBetweenScenes);
        SceneManager.LoadScene(sceneName);
    }

}
