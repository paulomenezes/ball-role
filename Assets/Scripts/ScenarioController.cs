using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour {
	float elapsed = 0;

	void Start () {
		
	}
	
	void Update () {
		if (elapsed < 2f) {
			elapsed += 0.001f;
		}

		transform.position -= new Vector3(0, 0, elapsed);

		if (transform.position.z < -20) {
			Destroy (gameObject);
		}
	}
}
