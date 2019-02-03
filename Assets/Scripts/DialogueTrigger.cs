using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    DialogEvent dialogEvent = new DialogEvent( new DialogTextBox[]
    {
        new DialogTextBox("* Oh, Kris!", "Ralsei", "shocked"),
        new DialogTextBox("* It's the training dummy I made!", "", "happy"),
        new DialogTextBox("* Now seems like a great chance to prepare for the enemy.", "Ralsei", "happy")
    }
    );
    public string dialogueID;
    private void OnTriggerEnter2D()
    {
        TriggerDialogue(dialogueID);
    }

    public void TriggerDialogue(string ID)
    {
        Debug.Log("Dialogue ID : " + ID);

        // JSON EXTRACTING STUFF GOES HERE, TO EXTRACT A DIALOGEVENT FROM JSON

        FindObjectOfType<DialogueManager>().StartDialogue(dialogEvent);
    }
}
