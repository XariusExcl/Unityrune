/*
(When attached to something, will trigger a dialogue when collided with the player)
Starts by desializing every DialogueEvent in the game inside of text_en.json and will trigger a dialogue based on the key that has been given inside of TriggerDialogue(key)
Also has a debug "error" text when the dialogue wasn't found.
talkTrigger is used when it should only trigger the dialogue when "talked" to (then you should link the Player's talk collider with it in the Editor)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Collider2D talkTrigger;
    private Dictionary<string, DialogEvent> textLibrary = new Dictionary<string, DialogEvent>();

    DialogEvent eventNotFound = new DialogEvent(new DialogTextBox[]
    {
        new DialogTextBox("* Oh, this is embarrassing.", "face_r_dark9"),
        new DialogTextBox("* You see, there was supposed to be some text here,", "face_r_dark9"),
        new DialogTextBox("* But it appears to be missing.", "face_r_dark9"),
        new DialogTextBox("* You may want to report the issue to the developer!", "face_r_dark9"),
    });

    public string dialogueID;

    void Start()
    {
        string json = Resources.Load<TextAsset>("Json/text_en").text;

        textLibrary = JsonConvert.DeserializeObject<Dictionary<string, DialogEvent>>(json);

        /*
        foreach(KeyValuePair<string, DialogEvent> pair in textLibrary)
        {
            Debug.Log("Key: " + pair.Key + " ; Textboxes: " + pair.Value.ToString());
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (talkTrigger != null) {
            if(talkTrigger == col)
                TriggerDialogue(dialogueID);
        } else
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
