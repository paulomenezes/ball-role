using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawmer : MonoBehaviour {
	private Material wallMaterial;
	private float elapsed = 5f;

	void Start () {
		wallMaterial = Resources.Load("Wall", typeof(Material)) as Material;
	}
	
	void Update () {
		elapsed += 0.1f;

		if (elapsed >= 10f) {
			elapsed = 0;

			var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.AddComponent<Rigidbody> ();
			cube.AddComponent<ScenarioController> ();
			cube.transform.position = new Vector3 (0, 1f, 0);
			cube.transform.localScale = new Vector3 (2 * Random.Range(1, 4), 2, 0.5f);

			Rigidbody rigidBody = cube.GetComponent<Rigidbody> ();
			rigidBody.isKinematic = true;
			rigidBody.useGravity = false;

			Renderer renderer = cube.GetComponent<Renderer> ();
			renderer.material = wallMaterial;
		}
	}
}
