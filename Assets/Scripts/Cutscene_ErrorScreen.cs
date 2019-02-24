using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene_ErrorScreen : MonoBehaviour
{   
    float sinceLastCall = 0f;
    float sinceLastTxtbox = -60f;
    int i = 1;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public GameObject backgroundMusic;

    void Update()
    {
        if(Time.timeSinceLevelLoad - sinceLastCall > 5f)
        {
            sinceLastCall = Time.timeSinceLevelLoad;
            dialogueManager.DisplayNextSentence();
        }
        
        if(Time.timeSinceLevelLoad - sinceLastTxtbox > 60f && i < 6)
        {
            sinceLastTxtbox = sinceLastCall = Time.timeSinceLevelLoad;

            dialogueTrigger.TriggerDialogue(("error_"+ i));
            i++;
        }
        if(Time.timeSinceLevelLoad > 287.75f)
        {
            backgroundMusic.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
