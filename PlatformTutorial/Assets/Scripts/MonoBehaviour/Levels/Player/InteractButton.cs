using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour {

	public bool interact;
	public static InteractButton instance;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else if (instance != this)
		{
			Destroy (gameObject);
		}
	}

	public void ButtonPressedDown (BaseEventData e) {
		interact = true;
	}

	public void ButtonPressedUp (BaseEventData e) {
		interact = false;
	}

	public bool IsInteract () {
		return interact;
	}


}
