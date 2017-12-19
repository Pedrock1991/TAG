using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager6 : MonoBehaviour {

	public int numberOfEggs;
	public Text eggCounter;
	private LevelManager LM;

	void Start () {
		LM = FindObjectOfType <LevelManager> ();
	}
	
	void Update () {
		if (LM.startBonus){
			LM.gameStarted = true;
			LM.startBonus = false;
		}

		if (numberOfEggs <= 0) {
			LM.Win ();
		}
		
		eggCounter.text = numberOfEggs.ToString ();
	}
}
