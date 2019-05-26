/*
Switches scenes when LoadScene(sceneName) is called.
This will be much more complex in the future, or maybe not, idk.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
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
