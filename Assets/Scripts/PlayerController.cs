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
	BoxCollider2D talkbc;
	Vector2 direction;

	float inputHorizontal = 0f;
	float inputVertical = 0f;
	float speedSquared = 0f;
	public static bool inMenu = false;

	void Start()
    {
        tr = GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		talkbc = talk.GetComponent<BoxCollider2D>();
    }
	void Update ()
	{	
		
		if (MenuTop.isOpen || inMenu) // If inside of a menu/textbox
		{
			inputHorizontal = 0f;
			inputVertical = 0f;
			anim.SetFloat("Speed", 0f);
		} else {
			inputHorizontal = Input.GetAxisRaw("Horizontal");
			inputVertical = Input.GetAxisRaw("Vertical");

			speedSquared = inputHorizontal*inputHorizontal + inputVertical*inputVertical;
			anim.SetFloat("Speed", speedSquared);

			if (speedSquared != 0f)
			{
				anim.SetFloat("Horizontal", inputHorizontal);
				anim.SetFloat("Vertical", inputVertical);
				direction = new Vector2(inputHorizontal/6, -.15f + inputVertical/6);
			}

			if (Input.GetButton("Sprint"))
			{
				anim.speed = 1.5f;
				inputHorizontal *= 1.5f;
				inputVertical *= 1.5f;
			} else { anim.speed = 1f; }

			if (Input.GetButtonDown("Confirm")) // Enter or Z key
			{
				talkbc.isTrigger = true;
				talk.SetActive(true);
				talk.transform.localPosition = direction;
			}
			if (Input.GetButtonUp("Confirm"))
			{
				talkbc.isTrigger = false;
				talk.SetActive(false); 
				talk.transform.localPosition = new Vector3(0, -.15f, 0);
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
	}
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(inputHorizontal, inputVertical);
		tr.position = new Vector3(Convert.ToSingle(Math.Round(tr.position.x, 2)),
                                  Convert.ToSingle(Math.Round(tr.position.y, 2)),
                                  tr.position.z);
	}
	
}
