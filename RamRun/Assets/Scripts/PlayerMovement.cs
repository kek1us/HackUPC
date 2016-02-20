﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private bool onFloor = false;
	public float jumpForce = 30;
	private Rigidbody2D rb = null;

	void Awake() {
		if (rb == null) {
			rb = GetComponent<Rigidbody2D> ();
		}
	}

	void Update () {
		// TODO: update to touch control
		if (Input.GetAxisRaw ("Vertical") > 0 && onFloor) {
			onFloor = false;
			rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Floor") {
			onFloor = true;
		}
	}


}
