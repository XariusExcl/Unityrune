using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // This will be much more complex in the future.
    // Or maybe not, idk.
    public string sceneName = "";
    public void LoadScene(string scene)
    {
        Debug.Log("Loading Scene : \"" + scene + "\"");
        SceneManager.LoadScene (sceneName:scene);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
    
}
