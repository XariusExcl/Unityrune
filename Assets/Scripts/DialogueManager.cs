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
	private AudioClip[] voicesClip;
	private int voiceIndex = 7;
	private AudioSource audioClip;

	void Start () {
		sentences = new Queue<string>();
		voicesClip = Resources.LoadAll<AudioClip>("Audio/Voices");
		Debug.Log("Loaded " + voicesClip.Length + " Voices!");
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
			var letterStr = letter.ToString();
			textboxTextSB.Append(letterStr);     // Appends letter for the typing effect
            textboxText.text = textboxTextSB.ToString(); // Converts to string to be displayed by the textbox

			if (letterStr == "," || letterStr == "." || letterStr == "?" || letterStr == "!")  // Don't play voice + longer pause if the appended letter are those
			{
				yield return new WaitForSeconds(.066f);

			} else if(letterStr != " " ) { // Normal pause, but no sound for spaces
				audioClip = GetComponent<AudioSource>();
				audioClip.clip = voicesClip[voiceIndex];
				audioClip.Play();
				Debug.Log("Playing audio...");
			}

			yield return new WaitForSeconds(.033f);
		}
	}

	void EndDialogue()
	{
		Textbox.SetActive(false);
        Debug.Log("End of dialogue");
	}

}
