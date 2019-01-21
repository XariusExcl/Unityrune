using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalseiController : MonoBehaviour {

	public Rigidbody2D rb;
	public Animator animator;

	float inputHorizontal = 0f;
	float inputVertical = 0f;
	
	// Update is called once per frame
	void Update () {
		// Getting the movement axes
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputVertical = Input.GetAxisRaw("Vertical");

		// Setting them in the animator
		animator.SetFloat("Horizontal", inputHorizontal);
		animator.SetFloat("Vertical", inputVertical);
	}

	void FixedUpdate() {
		// Moving the character
		rb.velocity = new Vector2(inputHorizontal, inputVertical);

	}
}
