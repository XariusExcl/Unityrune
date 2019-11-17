/*
(When attached to something, will trigger a dialogue when collided with the player)
Starts by desializing every DialogueEvent in the game inside of text_en.json and will trigger a dialogue based on the key that has been given inside of TriggerDialogue(key)
Also has a debug "error" text when the dialogue wasn't found.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string dialogueID;
    public bool automaticTrigger;
    Collider2D talkTrigger;
    private Dictionary<string, DialogEvent> textLibrary = new Dictionary<string, DialogEvent>();

    DialogEvent eventNotFound = new DialogEvent(new DialogTextBox[]
    {
        new DialogTextBox("* Oh, this is embarrassing.", "face_r_dark9"),
        new DialogTextBox("* You see, there was supposed to be some text here,", "face_r_dark9"),
        new DialogTextBox("* But it appears to be missing.", "face_r_dark9"),
    });

    void Start()
    {
        string json = Resources.Load<TextAsset>("Json/text_en").text;
        textLibrary = JsonConvert.DeserializeObject<Dictionary<string, DialogEvent>>(json);

        if (automaticTrigger) {
            talkTrigger = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
            if(talkTrigger == null) {Debug.Log("Dialogue Trigger : Player's BoxCollider2D not found!");}
        } else {
            talkTrigger = GameObject.FindGameObjectWithTag("TalkTrigger").GetComponent<BoxCollider2D>();
            if(talkTrigger == null) {Debug.Log("Dialogue Trigger : TalkTrigger's BoxCollider2D not found !");}
        }
        /*
        foreach(KeyValuePair<string, DialogEvent> pair in textLibrary)
        {
            Debug.Log("Key: " + pair.Key + " ; Textboxes: " + pair.Value.ToString());
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((!automaticTrigger && talkTrigger.isTrigger == true) || (automaticTrigger && col == talkTrigger)){
            TriggerDialogue(dialogueID);
        }
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
