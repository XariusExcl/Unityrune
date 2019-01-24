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

	public void StartDialogue (string[] dialogue)
	{
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
		StringBuilder textboxText = new StringBuilder("");
		foreach (char letter in sentence.ToCharArray())
		{
			textboxText.Append(letter.ToString());
			yield return null;
		}
	}

	void EndDialogue()
	{
		Textbox.SetActive(false);
        Debug.Log("End of dialogue");
	}

}
