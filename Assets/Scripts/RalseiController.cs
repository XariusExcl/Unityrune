using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalseiController : MonoBehaviour {

	public Rigidbody2D rb;
	public Animator animator;

	float inputHorizontal = 0f;
	float inputVertical = 0f;
	[HideInInspector]
	public bool inDialogue = false;

	
	// Update is called once per frame
	void Update ()
	{	
		if (!inDialogue)
		{
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputVertical = Input.GetAxisRaw("Vertical");
		} else {
			inputHorizontal = 0f;
			inputVertical = 0f;
		}

		/*
		if (Input.GetButtonDown("Confirm")) // Enter or Z key
		{
			Debug.Log("Confirm key pressed!");
		}

		if (Input.GetButtonDown("Cancel")) // Backspace or X key
		{
			Debug.Log("Cancel key pressed!");
		}

		if (Input.GetButtonDown("Menu")) // Right Ctrl or C key
		{
			Debug.Log("Menu key pressed!");
		}
		*/


		// Setting them in the animator
		animator.SetFloat("Horizontal", inputHorizontal);
		animator.SetFloat("Vertical", inputVertical);
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(inputHorizontal, inputVertical);
	}
}
