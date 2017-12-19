using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityController : MonoBehaviour {

	private Transform egg;
	private bool dig;

	void Start () {
		egg = gameObject.transform.parent;
	}

	void OnTriggerStay2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			if (InteractButton.instance.IsInteract ()) {
				if (!dig) {
					egg.position += Vector3.up;
					dig = true;
				}
			}
		}
	}
}
