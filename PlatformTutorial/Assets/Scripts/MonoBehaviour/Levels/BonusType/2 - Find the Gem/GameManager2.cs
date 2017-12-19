using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour { 

	public bool[] gemSlots = new bool[4];
	private int slotFulled;
	
	private LevelManager LM;

	void Start () {
		LM = FindObjectOfType <LevelManager> ();
	}

	void Update () {
		if (LM.startBonus){
			LM.gameStarted = true;
			LM.startBonus = false;
		}
		
		for (int i = 0; i < 4; i++) {
			if (gemSlots[i]) {
				slotFulled++;
			} else {
				slotFulled = 0;
			}
		}

		if (slotFulled >= 4) {
			LM.Win ();
		}
	}
}
