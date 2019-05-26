/*
(Attached to a TextboxManager)
A Textbox Manager manages the Textbox gameObject (enabling or disabling it), the text, the voice, and the image it has to display.
StartDialogue(dialogEvent) takes a DialogueEvent class attribute, which contains an array of DialogTextbox, another class that has a lot of useful properties (refer to their script to learn more about them).

When called, it will load the DialogTextBox(es) in a queue, ready to be read and displayed by DisplayNextSentence();
DisplayNextSentence will :
- Scroll the text with varying time delays depending on the values of ShortDelay and LongDelay.
- Speak with the voice of the Character (by reading everything before the "_").
- Display the face stored in Character.
- Use a custom size/position when specified (useful for cutscenes).
- Call EndDialogue() when the Queue of DialoxTextBox is over.

All in all, this is a pretty versatile script.
*/
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
	public SpriteRenderer textboxImage;
	[HideInInspector]
	public DialogTextBox Textbox;
	[HideInInspector]
	public string fullText;
    private Queue<DialogTextBox> Textboxes;
	private AudioClip voice;
	private AudioSource audioClip;
	private Coroutine co;
	private bool typing;

	void Start ()
	{
		audioClip = GetComponent<AudioSource>();
		Textboxes = new Queue<DialogTextBox>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Confirm"))
		{
			if (typing)
			{
				if (co != null) {StopCoroutine(co);}
				typing = false;
				textboxText.text = fullText;
			} else {
				DisplayNextSentence();
			}
		}
	}

	public void StartDialogue (DialogEvent dialogEvent)
	{
		RalseiController.inMenu = true;
		MenuTop.enableMenu = false;
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
		string voiceStr = "";

		if (Textboxes.Count == 0)
		{
			StopAllCoroutines();
			EndDialogue();
			return;
		}
		DialogTextBox Textbox = Textboxes.Dequeue();  // Loads next textbox in "Textbox"

		if (Textbox.Character != null)
		{
			string[] split = Textbox.Character.Split('_');  // Formatting :)
			voiceStr = split[0];
		}


		voice = Resources.Load<AudioClip>("Audio/Voices/Voice_" + voiceStr);  // Load the voice clip
		audioClip.clip = voice;


		textboxImage.sprite = Resources.Load<Sprite>("Sprites/Faces/" + Textbox.Character);  // Load the face to display


		if (Textbox.Pos != new Vector2(0, 0))
		{
			textboxText.rectTransform.anchoredPosition = Textbox.Pos;  // Use custom pos when set
		}else if(Textbox.Character != null){
			textboxText.rectTransform.anchoredPosition = new Vector2(-83, -12); // Default pos for character textboxes
		}else{
			textboxText.rectTransform.anchoredPosition = new Vector2(10, 0); // Default pos for floating text
		}


		if (Textbox.Size != new Vector2(0, 0))
		{
			textboxText.rectTransform.sizeDelta = Textbox.Size;  // Use custom size when set
		}else if(Textbox.Character == "Narrator" || Textbox.Character == null){
			textboxText.rectTransform.sizeDelta = new Vector2(1020,250);  // Use larger textarea when narrating
		}else{
			textboxText.rectTransform.sizeDelta = new Vector2(800,250);   // Default size
		}
		
		if (co != null) {StopCoroutine(co);}
		fullText = Textbox.Text;
		co = StartCoroutine(TypeSentence(fullText, Textbox.Character, Textbox.ShortDelay, Textbox.LongDelay));
	}

	IEnumerator TypeSentence (string sentence, string character, float shortDelay = .033f, float longDelay = .066f) // The typing and speaking engine
	{
		typing = true;

		if (shortDelay == 0){shortDelay = .033f;}
		if (longDelay == 0) {longDelay  = .066f;}

		StringBuilder textboxTextSB = new StringBuilder();
		foreach (char letter in sentence)
		{
			textboxTextSB.Append(letter);     			 // Appends letter for the typing effect
            textboxText.text = textboxTextSB.ToString(); // Converts to string to be displayed by the textbox

			char[] array = {',','.','?','!'};

			if (array.Contains(letter))		// Don't play voice + longer pause if the letter is one of those
			{
				yield return new WaitForSeconds(longDelay);

			} else if(letter != ' ') {		// Normal pause, but no sound for spaces
				audioClip.Play();
			}

			yield return new WaitForSeconds(shortDelay);
		}
		typing = false;
	}

	public void EndDialogue()
	{
		goTextbox.SetActive(false);
		textboxText.text = "";
		RalseiController.inMenu = false;
		MenuTop.enableMenu = true;
	}
}