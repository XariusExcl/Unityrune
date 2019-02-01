using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    string[] dialogue = { "* Oh, Kris!", "* It's the training dummy I made!", "* Now seems like a great chance to prepare for the enemy."};
    string[,] dialogueEvent = new string[,] {
    {"* Oh, Kris!", "Ralsei", "shocked"},
    {"* It's the training dummy I made!", "Ralsei", "happy"}, 
    {"* Now seems like a great chance to prepare for the enemy.", "Ralsei", "happy"}};


    public void TriggerDialogue(string dialogueEvent)
    {
        // JSON EXTRACTING STUFF GOES HERE

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, "Ralsei", "happy");
    }
}
