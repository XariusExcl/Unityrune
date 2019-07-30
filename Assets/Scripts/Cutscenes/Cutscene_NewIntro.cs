using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class Cutscene_NewIntro : MonoBehaviour
{
    Dictionary<string, DialogEvent> textLibrary = new Dictionary<string, DialogEvent>();
    Transform tr;
    public string prefix;
    public string sceneName;
    public DialogueManager dialogueManager_a;
    public DialogueManager dialogueManager_b;
    public DialogueManager dialogueManager_c;
    int i = 0;
    void Start()
    {
        tr = GetComponent<Transform>();
        string json = Resources.Load<TextAsset>("Json/text_en").text;
        textLibrary = JsonConvert.DeserializeObject<Dictionary<string, DialogEvent>>(json);
    }
    public void StartDialogueA()
    {
        i++;
        dialogueManager_a.StartDialogue(textLibrary[prefix + i]);
    }
    public void StartDialogueB()
    {
        dialogueManager_b.StartDialogue(textLibrary[prefix + i + "b"]);
    }
    public void StartDialogueC()
    {
        dialogueManager_c.StartDialogue(textLibrary[prefix + i + "c"]);
    }
    
    public void DisplayNextSentenceA()
    {
        dialogueManager_a.DisplayNextSentence();
    }
    public void DisplayNextSentenceB()
    {
        dialogueManager_b.DisplayNextSentence();
    }
    public void DisplayNextSentenceC()
    {
        dialogueManager_c.DisplayNextSentence();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    void LateUpdate()
    {
        tr.position = new Vector3(Convert.ToSingle(Math.Round((tr.position.x)/2, 2))*2,
                                  Convert.ToSingle(Math.Round((tr.position.y)/2, 2))*2,
                                  tr.position.z);
    }
}
