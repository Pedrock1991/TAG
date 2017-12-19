using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplayManager : MonoBehaviour {
	
	
	public Text copperCoinsCounter;
	public Text silverCoinsCounter;
	public Text goldCoinsCounter;
	
	void Update () {
		ShowCoins ();
	}

	void ShowCoins () {
		copperCoinsCounter.text = GameManager.instance.GetCooperCoins ().ToString ();
		silverCoinsCounter.text = GameManager.instance.GetSiverCoins ().ToString ();
		goldCoinsCounter.text = GameManager.instance.GetGoldCoins ().ToString ();
	}
}
