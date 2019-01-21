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
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputVertical = Input.GetAxisRaw("Vertical");

		animator.SetFloat("Horizontal", inputHorizontal);
		animator.SetFloat("Vertical", inputVertical);
	}

	void FixedUpdate() {
		rb.velocity = new Vector2(inputHorizontal, inputVertical);

	}
}
