using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinWindowStarController : MonoBehaviour {

	private float rotSpeed = 180.0f;
	private bool rotCheck = true;

	void Start () {
		
	}
	
	void Update () {
		if (rotCheck) {
			transform.Rotate (0, Time.deltaTime * rotSpeed, 0, Space.World);
			transform.GetComponent <Image> ().color = new Color (transform.GetComponent <Image> ().color.r, 
																	transform.GetComponent <Image> ().color.g,
																	transform.GetComponent <Image> ().color.b,
																	transform.GetComponent <Image> ().color.a+(Time.deltaTime/1.5f));
			if (transform.rotation.y <= 0) {
				rotCheck = false;
			}
		}
	}
}
