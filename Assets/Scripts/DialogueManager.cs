using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text textboxText;
    public GameObject Textbox;

    private Queue<string> sentences;
	void Start () {
		sentences = new Queue<string>();
	}

    // DISPLAYING DOESN'T WORK, NEED TO FIX THAT WHEN YOU COME BACK JULES
	public void StartDialogue (string[] dialogu) // "dialogu" is a temporary fix, i'm directly implementing the array inside the function
	{
        string[] dialogue = new string[3];
        dialogue[0] = "* Oh, Kris!";
        dialogue[1] = "* It's the training dummy I made!";
        dialogue[2] = "* Why wouldn't we do a little bit of training then...?";

        // The actual code is here.

        Debug.Log("Starting Dialogue");

		Textbox.SetActive(true);

		sentences.Clear();

		foreach (string sentence in dialogue)
		{
            Debug.Log("Enqueing...");
			sentences.Enqueue(sentence);
		}
        
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
        Debug.Log("Displaying a Sentence!");
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		StringBuilder textboxTextSB = new StringBuilder("");
		foreach (char letter in sentence.ToCharArray())
		{
			textboxTextSB.Append(letter.ToString());
            Debug.Log(textboxText.ToString());
			yield return null;
            textboxText.text = textboxTextSB.ToString();
		}
	}

	void EndDialogue()
	{
		Textbox.SetActive(false);
        Debug.Log("End of dialogue");
	}

}
