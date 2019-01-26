using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // This will be much more complex in the future.
    public void LoadScene()
    {
        Debug.Log("Loading Scene...");
        SceneManager.LoadScene (sceneName:"Ralsei test scene");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
    
}
