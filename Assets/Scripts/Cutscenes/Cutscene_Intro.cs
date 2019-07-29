using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class Cutscene_Intro : MonoBehaviour
{
    // I bypassed the dialogueTrigger completely, to be able to start multiple textboxes at once
    // Downside is, we'll need to do that for every cutscene which needs multiple textboxes...
    // It could be nice to add this feature to dialogueTrigger, or find a way to get rid of him :)
    // Also, we need to be able to modify text speed and dialogue box size when needed (with default values, to de-clutter the json)
    
    private Dictionary<string, DialogEvent> textLibrary = new Dictionary<string, DialogEvent>();
    public DialogueManager dialogueManager_a;
    public DialogueManager dialogueManager_b;
    public DialogueManager dialogueManager_c;
    public GameObject mask;
    public GameObject castle;
    public GameObject balance1;
    public GameObject balance2;
    public GameObject earth;
    public GameObject hope;
    public GameObject threeheroes;
    public GameObject human;
    public GameObject monster;
    public GameObject prince;
    public GameObject angelsheaven;
    public GameObject fountains;

    int i = 1;
    void Start()
    {
        string json = Resources.Load<TextAsset>("Json/text_en").text;
        textLibrary = JsonConvert.DeserializeObject<Dictionary<string, DialogEvent>>(json);
    }
    public void StartDialogue()
    {

    }
    
    public void DisplayNextSentence()
    {
        
    }
    void Update()
    {
        switch(i)
        {
            case 1:
                if (Time.timeSinceLevelLoad > 0.33f)
                {
                    Debug.Log("intro_1");
                    dialogueManager_a.StartDialogue(textLibrary["intro_" + i]);
                    i++;
                }
                break;
            case 2:
                if (Time.timeSinceLevelLoad > 7.43f)
                {
                    Debug.Log("intro_2");
                    dialogueManager_a.DisplayNextSentence();

                    dialogueManager_a.StartDialogue(textLibrary["intro_" + i + "a"]);
                    dialogueManager_b.StartDialogue(textLibrary["intro_" + i + "b"]);
                    dialogueManager_a.Invoke("DisplayNextSentence", 4f);
                    dialogueManager_b.Invoke("DisplayNextSentence", 4f);
                    i++;
                }
                break;
            case 3:
                if (Time.timeSinceLevelLoad > 15.43f)
                {
                    Debug.Log("intro_3");
                    dialogueManager_b.DisplayNextSentence();

                    dialogueManager_a.StartDialogue(textLibrary["intro_" + i + "a"]);
                    StartCoroutine(StartDialogueInvokeB("intro_" + i + "b", 3.5f));
                    dialogueManager_b.Invoke("DisplayNextSentence", 6.6f);
                    i++;
                }
                break;
            case 4:
                if (Time.timeSinceLevelLoad > 23.73f)
                {
                    Debug.Log("intro_4");
                    mask.SetActive(false);
                    castle.SetActive(false);
                    balance1.SetActive(true);
                    balance2.SetActive(true);
                    dialogueManager_a.DisplayNextSentence();

                    dialogueManager_a.StartDialogue(textLibrary["intro_" + i]);
                    dialogueManager_a.Invoke("DisplayNextSentence", 4.7f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 8.96f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 13.5f);
                    i++;
                }
                break;
            case 5:
                if (Time.timeSinceLevelLoad > 42.03f)
                {
                    Debug.Log("intro_5");
                    balance1.SetActive(false);
                    balance2.SetActive(false);
                    hope.SetActive(true);
                    threeheroes.SetActive(true);
                    earth.SetActive(true);
                    dialogueManager_a.DisplayNextSentence();

                    dialogueManager_a.StartDialogue(textLibrary["intro_" + i]);
                    dialogueManager_a.Invoke("DisplayNextSentence", 4.57f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 9.17f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 13.77f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 18.34f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 22.94f);
                    i++;
                }
                break;
            case 6:
                if (Time.timeSinceLevelLoad > 69.40f)
                {
                    Debug.Log("intro_6");
                    hope.SetActive(false);
                    earth.SetActive(false);
                    threeheroes.SetActive(false);
                    human.SetActive(true);
                    monster.SetActive(true);
                    prince.SetActive(true);
 
                    dialogueManager_a.StartDialogue(textLibrary["intro_" + i + "a"]);
                    StartCoroutine(StartDialogueInvokeB("intro_" + i + "b", 2.46f));
                    StartCoroutine(StartDialogueInvokeC("intro_" + i + "c", 4.76f));
                    i++;
                }
                break;
            case 7:
                if (Time.timeSinceLevelLoad > 78.80f)
                {
                    Debug.Log("intro_7");
                    human.SetActive(false);
                    monster.SetActive(false);
                    prince.SetActive(false);
                    angelsheaven.SetActive(true);
                    fountains.SetActive(true);
                    mask.SetActive(true);

                    dialogueManager_a.DisplayNextSentence();
                    dialogueManager_b.DisplayNextSentence();
                    dialogueManager_c.DisplayNextSentence();

                    dialogueManager_a.StartDialogue(textLibrary["intro_" + i]);
                    dialogueManager_a.Invoke("DisplayNextSentence", 4.56f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 9.16f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 13.76f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 18.36f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 22.93f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 27.53f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 33.13f);
                    dialogueManager_a.Invoke("DisplayNextSentence", 39.66f);
                    i++;
                }
                break;
            case 8:
                if(Time.timeSinceLevelLoad > 129f)
                {
                    SceneManager.LoadScene ("MainMenu");
                }
                break;
        }
    }
        
    // This is the workaround to be able to "Invoke" with parameters, don't mind that.
    IEnumerator StartDialogueInvokeB(string key, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        dialogueManager_b.StartDialogue(textLibrary[key]);
    }
        IEnumerator StartDialogueInvokeC(string key, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        dialogueManager_c.StartDialogue(textLibrary[key]);
    }
    
}
