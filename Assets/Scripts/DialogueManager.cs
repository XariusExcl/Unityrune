using System.Collections;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text textboxText;
    public GameObject goTextbox;
    private Queue<DialogTextBox> Textboxes;
	private AudioClip voice;
	private AudioSource audioClip;
	public TextboxImageManager textboxImageManager;

	void Start ()
	{
		Textboxes = new Queue<DialogTextBox>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Confirm"))
		{
			DisplayNextSentence();
		}
	}

	public void StartDialogue (DialogEvent dialogEvent)
	{
		RalseiController.inMenu = true;
		Textboxes.Clear();
		goTextbox.SetActive(true);

		foreach(DialogTextBox Textbox in dialogEvent.TextBoxes)
		{
			Textboxes.Enqueue(Textbox);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (Textboxes.Count == 0)
		{
			StopAllCoroutines();
			EndDialogue();
			return;
		}
		DialogTextBox Textbox = Textboxes.Dequeue();  // Loads next textbox in "Textbox"

		voice = Resources.Load<AudioClip>("Audio/Voices/Voice_" + Textbox.Character);     			   // Load the voice clip

		textboxImageManager.DisplayImage(Textbox.Character + "_" + Textbox.Face);  // Load the face to display

		if(Textbox.Character == "" || Textbox.Face == "" )   // Use larger textarea when face/character isn't specified
		{
			textboxText.rectTransform.sizeDelta = new Vector2(1000,250);
		}else{
			textboxText.rectTransform.sizeDelta = new Vector2(800,250);
		}

		StopAllCoroutines();
		StartCoroutine(TypeSentence(Textbox.Text));
	}

	IEnumerator TypeSentence (string sentence) // The typing and speaking engine
	{
		StringBuilder textboxTextSB = new StringBuilder("");
		foreach (char letter in sentence)
		{
			textboxTextSB.Append(letter);     			 // Appends letter for the typing effect
            textboxText.text = textboxTextSB.ToString(); // Converts to string to be displayed by the textbox

			char[] array = {',','.','?','!'};

			if (array.Contains(letter))		// Don't play voice + longer pause if the letter is one of those
			{
				yield return new WaitForSeconds(.066f);

			} else if(letter != ' ') {		// Normal pause, but no sound for spaces
				audioClip = GetComponent<AudioSource>();
				audioClip.clip = voice;
				audioClip.Play();
			}

			yield return new WaitForSeconds(.033f);
		}
	}

	void EndDialogue()
	{
		goTextbox.SetActive(false);
		RalseiController.inMenu = false; // there might be an other way but whatever
	}
}