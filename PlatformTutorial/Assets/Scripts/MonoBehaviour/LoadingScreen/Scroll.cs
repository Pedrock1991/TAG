using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	public float speed = 0.5f;

	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed, 0);

		Renderer rend;

		rend = GetComponent<Renderer> ();

		rend.material.mainTextureOffset = offset;
	}
}
