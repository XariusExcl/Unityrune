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
using Newtonsoft.Json;

public class DialogueManager : MonoBehaviour
{
    public Text textboxText;
    public GameObject goTextbox;
	public Image textboxImage;
	[HideInInspector]
	public DialogTextBox Textbox;
	[HideInInspector]
	public string fullText;
    Queue<DialogTextBox> Textboxes;
	Dictionary<string, string> Faces = new Dictionary<string, string>();
	AudioClip voice;
	AudioSource audioClip;
	Coroutine co;
	RectTransform rt;
	bool typing;

	void Start ()
	{
		audioClip = GetComponent<AudioSource>();
		Textboxes = new Queue<DialogTextBox>();
		rt = textboxImage.GetComponent<RectTransform>();
        string json = Resources.Load<TextAsset>("Json/faces").text;
        Faces = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
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
		PlayerController.inMenu = true;
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
		DialogTextBox Textbox = Textboxes.Dequeue();

		// VOICE OF THE TEXTBOX
		if (Textbox.Character != null)
		{
			string[] split = Textbox.Character.Split('_');  // Formatting :)
			voiceStr = split[0];
		}
		voice = Resources.Load<AudioClip>("Audio/Voices/Voice_" + voiceStr);
		audioClip.clip = voice;

		// FACE SPRITE OF THE TEXTBOX
		textboxImage.sprite = Resources.Load<Sprite>("Sprites/Faces/" + Faces[Textbox.Character]);
        rt.sizeDelta = new Vector2 (textboxImage.sprite.rect.width, textboxImage.sprite.rect.height);

		// POSITION OF THE TEXTBOX RECT
		if (Textbox.Pos != new Vector2(0, 0))
		{
			textboxText.rectTransform.anchoredPosition = Textbox.Pos;  // Use custom pos when set
		} else if(Textbox.Character != null) {
			textboxText.rectTransform.anchoredPosition = new Vector2(-42, -6); // Default pos for character textboxes
		} else {
			textboxText.rectTransform.anchoredPosition = new Vector2(5, 0); // Default pos for floating text
		}

		// SIZE OF THE TEXTBOX RECT
		if (Textbox.Size != new Vector2(0, 0))
		{
			textboxText.rectTransform.sizeDelta = Textbox.Size;  // Use custom size when set
		} else if (Textbox.Character == "Narrator" || Textbox.Character == null){
			textboxText.rectTransform.sizeDelta = new Vector2(505,125);  // Use larger textarea when narrating
		} else {
			textboxText.rectTransform.sizeDelta = new Vector2(400,125);   // Default size
		}
		
		// TEXT FORMATTING
		fullText = WordWrap(Textbox.Text, -2 + (int)textboxText.rectTransform.sizeDelta.x/16);
		Debug.Log((int)textboxText.rectTransform.sizeDelta.x/16);

		if (co != null) 
			StopCoroutine(co);

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

			if (array.Contains(letter))		// No sound, longer pause
			{
				yield return new WaitForSeconds(longDelay);

			} else if(letter != ' ') {		// Normal pause, no sound
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
		PlayerController.inMenu = false;
		MenuTop.enableMenu = true;
	}

	private static string WordWrap(string text, int maxLineLength)
	{
		var list = new List<string>();

		int currentIndex;
		var lastWrap = 0;
		var whitespace = new[] {' ', '\r', '\n', '\t'};
		do
		{
			currentIndex =
				lastWrap +
				maxLineLength > text.Length
					? text.Length
					: (text.LastIndexOfAny(new[] {' ', ',', '.', '?', '!', ':', ';', '-', '\n', '\r', '\t'},
							Math.Min(text.Length - 1, lastWrap + maxLineLength)) + 1);
			if (currentIndex <= lastWrap)
				currentIndex = Math.Min(lastWrap + maxLineLength, text.Length);
			list.Add(text.Substring(lastWrap, currentIndex - lastWrap).Trim(whitespace));
			lastWrap = currentIndex;
		} while (currentIndex < text.Length);

		string str = "";

		foreach (string line in list)
			str += line + "\n";

		return str.TrimEnd('\n');
	}
}