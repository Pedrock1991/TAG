using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public int timer;
	public Text timerDisplay;

	public float time;
	private int timeInt;

	private LevelManager LM;

	void Start () {
		timerDisplay = GetComponent <Text> ();
		LM = FindObjectOfType <LevelManager> ();
		time = timer;
	}
	
	void Update () {
		if (LM.gameStarted) {
			if (time > 0) {
				time -= Time.deltaTime;
				timeInt = (int) time;
				timerDisplay.text = timeInt.ToString ();
			}

			if (time <= 0) {
				Debug.Log ("Time Over");
				LM.Lose ();
			}
		}
	}
}
