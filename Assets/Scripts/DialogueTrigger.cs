using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    string[] dialogue = {"* Oh, Kris!", "* It's the training dummy I made!", "* Now seems like a great chance to prepare for the enemy."};

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
