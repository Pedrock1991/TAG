using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAngleMoviment : MonoBehaviour {

	public float speedH = 2.0f;
	public float speedV = 2.0f;
	public float minYaw = 40.0f;
	public float minPitch = 40.0f;
	public float maxYaw = 60.0f;
	public float maxPitch = 60.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButton(1))
		{
			yaw += speedH * Input.GetAxis("Mouse X");
			//yaw = Mathf.Clamp(yaw, minYaw, maxYaw); // Y
			pitch -= speedV * Input.GetAxis ("Mouse Y");
			pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
			transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
		}

	}
}
