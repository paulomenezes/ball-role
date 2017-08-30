using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody rb;

	private float elapsed = 0;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		rb.AddForce (movement * speed);
	}

	void Update () {
		if (gameObject.transform.position.z < -12) {
			// Vector3.Lerp (gameObject.transform.position, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -12), 0.5f);
		}
	}
}
