using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindowManager : MonoBehaviour {

	void Awake () {
		PauseGame ();
	}

	public void PauseGame () {
		Time.timeScale = 0;
	}

	public void UnPauseGame () {
		Time.timeScale = 1;
	}

}
