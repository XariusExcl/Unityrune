using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{


    public string[] dialogue = {"* Oh, Kris!", "* It's the training dummy I made!", "* Why wouldn't we do a little bit of training then...?"};

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
