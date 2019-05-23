using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public string dialogueID;
    private void OnTriggerEnter()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue(dialogueID);
    }
}
