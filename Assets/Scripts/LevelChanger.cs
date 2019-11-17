/*
Handles all the scene switching work.
    LoadScene(sceneName) switches scenes instantly.
    QuitGame() quits the... game.
    FadeToLevel(string level) fades to black and transitions to the next level (intended of use in gameplay)
*/
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    Animator animator;
    PlayerController playerpc;
    private string levelToLoad;

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if (playerpc == null)
        {
            try
            {
                playerpc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                playerpc.TeleportToDoor();
            }
            catch (NullReferenceException nre)
            {
                // Damn bro it's fine, we're in a non-gameplay scene chill
            }
        }
        // Debug.Log(mode);
    }

    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        try
        {
            playerpc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        catch (NullReferenceException nre)
        {
            // Damn bro it's fine, we're in a non-gameplay scene chill
        }

    }

    public void FadeToLevel(string level)
    {
        playerpc.lastRoom = SceneManager.GetActiveScene().name;
        levelToLoad = level;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        LoadScene(levelToLoad);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(sceneName: scene);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}

