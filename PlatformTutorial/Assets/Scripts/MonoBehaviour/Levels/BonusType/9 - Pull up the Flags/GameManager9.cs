using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager9 : MonoBehaviour {

	public GameObject[] flags;
	public Text flagsCounter;
	public int numberOfFlags;
	public float flagTime;

	private LevelManager LM;

	void Start () {
		numberOfFlags = flags.Length;
		LM = FindObjectOfType <LevelManager> ();
	}
	
	void Update () {
		if (LM.startBonus){
			LM.gameStarted = true;
			LM.startBonus = false;
		}

		if (numberOfFlags <= 0) {
			LM.Win ();
		}

		flagsCounter.text = numberOfFlags.ToString ();
	}
}
