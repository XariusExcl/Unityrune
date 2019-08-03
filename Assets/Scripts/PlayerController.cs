/*
(Attached to the player-controlled character)
Moves the character, and freezes their movement when inside of a menu/textbox.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;
	Transform tr;
	public GameObject talk;
	Vector2 direction;

	float inputHorizontal = 0f;
	float inputVertical = 0f;
	public static bool inMenu = false;

	void Start()
    {
        tr = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }
	void Update ()
	{	
		
		if (MenuTop.isOpen || inMenu) // If inside of a menu/textbox
		{
			inputHorizontal = 0f;
			inputVertical = 0f;
		} else {
			inputHorizontal = Input.GetAxisRaw("Horizontal");
			inputVertical = Input.GetAxisRaw("Vertical");
			
			if (inputHorizontal != 0f || inputVertical != 0f)
				direction = new Vector2(inputHorizontal/5, -.15f + inputVertical/5);


			if (Input.GetButton("Sprint"))
			{
				inputHorizontal *= 1.5f;
				inputVertical *= 1.5f;
			}

			if (Input.GetButtonDown("Confirm")) // Enter or Z key
			{
				talk.SetActive(true);
				talk.transform.localPosition = direction;
			}
			if (Input.GetButtonUp("Confirm"))
			{
				talk.gameObject.SetActive(false);
			}	
		}

		/*
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
		anim.SetFloat("Horizontal", inputHorizontal);
		anim.SetFloat("Vertical", inputVertical);
	}
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(inputHorizontal, inputVertical);
		tr.position = new Vector3(Convert.ToSingle(Math.Round(tr.position.x, 2)),
                                  Convert.ToSingle(Math.Round(tr.position.y, 2)),
                                  tr.position.z);
	}
	
}
