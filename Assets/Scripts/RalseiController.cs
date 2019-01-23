using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalseiController : MonoBehaviour {

	public Rigidbody2D rb;
	public Animator animator;

	float inputHorizontal = 0f;
	float inputVertical = 0f;
	bool inputConfirm = false;
	bool inputCancel = false;
	bool inputMenu = false;
	
	// Update is called once per frame
	void Update () {
		// Getting the movement axes
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputVertical = Input.GetAxisRaw("Vertical");

		// Getting button presses (will be ported inside unity soon)
		inputConfirm = (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z));
		inputCancel = (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.X));
		inputMenu = (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.C));

		// Setting them in the animator
		animator.SetFloat("Horizontal", inputHorizontal);
		animator.SetFloat("Vertical", inputVertical);
	}

	void FixedUpdate() {
		// Moving the character
		rb.velocity = new Vector2(inputHorizontal, inputVertical);

	}
}
