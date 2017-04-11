using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Animator playerAnimator;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;
	private float turningSpeed = 20f;
	private Rigidbody playerRigidBody;


	// Use this for initialization
	void Start () {
		// Gather components from the player GameObject
		playerAnimator = GetComponent<Animator> ();

		playerRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Gets movement wasd
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		// Set left/right fwd/back but no vertical (no "jump")
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

	//Doesn't run every frame
	void FixedUpdate () {
		// If player is pressing movement keys
		if (movement != Vector3.zero) {

			// Direct frog in direction of movement vector
			Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

			// and create another rotation that moves from the current rotation to target rotation
			Quaternion newRotation = Quaternion.Lerp (playerRigidBody.rotation, targetRotation, turningSpeed * Time.deltaTime);

			// and change the player's rotation to the new inremental rotation
			playerRigidBody.MoveRotation (newRotation);

			// Move frog at 3 speed
			playerAnimator.SetFloat ("Speed", 3f);
		} else {
			// stop animation
			playerAnimator.SetFloat ("Speed", 0f);
		}


	}

}
