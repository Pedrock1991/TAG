using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour {

	public int numberOfStars;
	public Text starsCounter;

	private LevelManager LM;

	void Start () {
		LM = FindObjectOfType <LevelManager> ();
	}
	
	void Update () {
		if (LM.startBonus){
			LM.gameStarted = true;
			LM.startBonus = false;
		}

		if (numberOfStars <= 0) {
			LM.Win ();
		}
		
		starsCounter.text = numberOfStars.ToString ();
	}
}
