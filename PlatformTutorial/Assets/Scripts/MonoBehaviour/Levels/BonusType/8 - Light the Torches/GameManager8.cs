using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager8 : MonoBehaviour {

	public GameObject[] torchs;
	public Text torchsCounter;
	public int numberOfTorchs;
	
	private LevelManager LM;

	void Start () {
		numberOfTorchs = torchs.Length;
		LM = FindObjectOfType <LevelManager> ();
	}
	
	void Update () {
		if (LM.startBonus){
			LM.gameStarted = true;
			LM.startBonus = false;
		}

		if (numberOfTorchs <= 0) {
			LM.Win ();
		}

		torchsCounter.text = numberOfTorchs.ToString ();
	}
}
