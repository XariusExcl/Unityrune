using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DialogueTrigger : MonoBehaviour
{
    private Dictionary<string, DialogEvent> textLibrary = new Dictionary<string, DialogEvent>();
       
    DialogEvent dialogEvent = new DialogEvent( new DialogTextBox[]
    {
        new DialogTextBox("* Oh, Kris!", "Ralsei", "shocked"),
        new DialogTextBox("* It's the training dummy I made!", "", "happy"),
        new DialogTextBox("* Now seems like a great chance to prepare for the enemy.", "Ralsei", "happy")
    });

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

        // JSON EXTRACTING STUFF GOES HERE, TO EXTRACT A DIALOGEVENT FROM JSON

        // FindObjectOfType<DialogueManager>().StartDialogue(dialogEvent);

        if (textLibrary.ContainsKey(ID))
            FindObjectOfType<DialogueManager>().StartDialogue(textLibrary[ID]);
        else
            FindObjectOfType<DialogueManager>().StartDialogue(eventNotFound);
    }
}
