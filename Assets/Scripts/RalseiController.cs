/*
(Attached to Ralsei)
Moves Ralsei, and freezes their movement when inside of a menu/textbox.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalseiController : MonoBehaviour {

	public Rigidbody2D rb;
	public Animator animator;
	Transform tr;

	float inputHorizontal = 0f;
	float inputVertical = 0f;
	public static bool inMenu = false;

	void Start()
    {
        tr = GetComponent<Transform>();
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
		}

		if (Input.GetButton("Sprint"))
		{
			inputHorizontal *= 1.5f;
			inputVertical *= 1.5f;
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
		tr.position = new Vector3(Convert.ToSingle(Math.Round(tr.position.x, 2)),
                                  Convert.ToSingle(Math.Round(tr.position.y, 2)),
                                  tr.position.z);
	}
	
}
