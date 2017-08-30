using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawmer : MonoBehaviour {
	private Material wallMaterial;
	private float elapsed = 5f;
	private float offset = 10;

	void Start () {
		wallMaterial = Resources.Load("Wall", typeof(Material)) as Material;
	}
	
	void Update () {
		elapsed += 0.1f;

		if (elapsed >= 10f) {
			elapsed = 0;

			var plane = GameObject.Find ("Plane");
			var planeMesh = plane.GetComponent<MeshFilter> ().mesh;
			var bounds = planeMesh.bounds;

			float floor = plane.transform.localScale.x * bounds.size.x;
			float width1 = Random.Range (1, floor - offset);
			float width2 = Random.Range (1, floor - width1 - offset);

			offset = floor / 5;

			float x1 = -(floor / 2) + (width1 / 2);
			float x2 = (floor / 2) - (width2 / 2);

			AddWall (x1, width1);
			AddWall (x2, width2);
		}
	}

	void AddWall(float x, float width) {
		var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.position = new Vector3 (x, 1f, 0);
		cube.transform.localScale = new Vector3 (width, 2, 0.5f);

		cube.AddComponent<Rigidbody> ();
		cube.AddComponent<ScenarioController> ();

		Rigidbody rigidBody = cube.GetComponent<Rigidbody> ();
		rigidBody.isKinematic = true;
		rigidBody.useGravity = false;

		Renderer renderer = cube.GetComponent<Renderer> ();
		renderer.material = wallMaterial;
	}
}
