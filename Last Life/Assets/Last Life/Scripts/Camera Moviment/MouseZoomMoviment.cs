using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseZoomMoviment : MonoBehaviour {

	// Variables Zoom
	public float minFov = 30f;
	public float maxFov = 200f;
	public float sensitivity = 100f;
	
	// Update is called once per frame
	void Update () {
		//Zoom
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);
		Camera.main.fieldOfView = fov;
	}
}
