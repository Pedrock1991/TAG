using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour {

	private Transform obj;
	private float rotSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		obj = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		obj.Rotate (0, Time.deltaTime * rotSpeed, 0, Space.World);
	}
}
