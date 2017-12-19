using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float speed = 5f;
	public bool isMoving { get; private set; }

	public Pin currentPin { get; private set; }
	private Pin _targetPin;
	private PlanetManager _planetManager;

	public GameObject[] Male = new GameObject[5];
	public GameObject[] Female = new GameObject[5];

	public int selected;

	public void Initialise (PlanetManager planetManager, Pin startPin) {
		_planetManager = planetManager;
		SetCurrentPin (startPin);
	}

	void Start () {

		selected = (int) Random.Range (0, 5);

		if (GameManager.instance.GetGenreMale ()) {
			for (int i = 0; i < 5; i++) {
				Male [i].SetActive (false);
				Female [i].SetActive (false);
				if (i == selected) {
					Male [i].SetActive (true);
				}
			}
		}
		if (GameManager.instance.GetGenreFemale ()) {
			for (int j = 0; j < 5; j++) {
				Male [j].SetActive (false);
				Female [j].SetActive (false);
				if (j == selected) {
					Female [j].SetActive (true);
				}
			}
		}

	}

	void Update () {
		if (_targetPin == null)
			return;

		var currentPosition = transform.position;
		var targetPosition = _targetPin.transform.position;

		if (Vector3.Distance (currentPosition, targetPosition) > .02f) {
			transform.position = Vector3.MoveTowards (currentPosition,
													targetPosition,
													Time.deltaTime * speed);
		} else {
			if (_targetPin.IsAutomatic) {
				var pin = _targetPin.GetNextPin (currentPin);
				MoveToPin (pin);
			} else {
				SetCurrentPin (_targetPin);
			}
		}
	}

	public void TrySetDirection(Direction direction) {
		var pin = currentPin.GetPinInDirection (direction);

		if (pin == null) {
			return;
		}

		MoveToPin (pin);
	}

	private void MoveToPin (Pin pin) {
		_targetPin = pin;
		isMoving = true;
	}

	public void SetCurrentPin (Pin pin) {
		currentPin = pin;
		_targetPin = null;
		transform.position = pin.transform.position;
		isMoving = false;

		_planetManager.UpdateGui ();
	}
}
