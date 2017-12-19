using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialWindowManager : MonoBehaviour {

	public static InitialWindowManager instance;

	private bool isReady = false;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void SetReady ()
	{
		isReady = true;
	}

	public bool GetIsReady()
	{
		return isReady;
	}
}
