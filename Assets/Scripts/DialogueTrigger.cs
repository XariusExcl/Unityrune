using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private Dictionary<string, DialogEvent> textLibrary = new Dictionary<string, DialogEvent>();

    DialogEvent eventNotFound = new DialogEvent(new DialogTextBox[]
    {
        new DialogTextBox("* Oh, this is embarrassing.", "Ralsei", "mspaint"),
        new DialogTextBox("* You see, there was supposed to be some text here,", "Ralsei", "mspaint"),
        new DialogTextBox("* But it appears to be missing.", "Ralsei", "mspaint"),
        new DialogTextBox("* You may want to report the issue to the developer!", "Ralsei", "mspaint"),
    });

    public string dialogueID;

    void Start()
    {
        string json = Resources.Load<TextAsset>("Json/text_en").text;

        textLibrary = JsonConvert.DeserializeObject<Dictionary<string, DialogEvent>>(json);   
        
        foreach(KeyValuePair<string, DialogEvent> pair in textLibrary)
        {
            Debug.Log("Key: " + pair.Key + " ; Textboxes: " + pair.Value.ToString());
        }
    }

    private void OnTriggerEnter2D()
    {
        TriggerDialogue(dialogueID);
    }

    public void TriggerDialogue(string ID)
    {
        Debug.Log("Dialogue ID : " + ID);

        if (textLibrary.ContainsKey(ID))
            dialogueManager.StartDialogue(textLibrary[ID]);
        else
            dialogueManager.StartDialogue(eventNotFound);
    }
}
