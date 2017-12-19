using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LowLifeWindowManager : MonoBehaviour {
	Character character;
	int cost;
	bool showCost = false;
	public Text restoreCost;
	public GameObject lowLiveWindow;
	public GameObject shopWindow;

	void Update () {
		if (GameObject.Find ("Character") != null) {
			character = GameObject.Find ("Character").GetComponent <Character> ();
		}
		if (!showCost) {
			ShowCost ();
		}
	}

	void ShowCost () {
		int health;
		health = GameManager.instance.GetHealth ();
		if (health == 0) {
			cost = 10;
		} else {
			cost = (health - 4) * 2;
		}
		restoreCost.text = cost.ToString ();
		showCost = true;
	}
	public void Restore () {
		if (GameManager.instance.GetGoldCoins () > cost) {
			GameManager.instance.SetGoldCoins (-cost);
			switch (GameManager.instance.GetAlien ()) {
				case 1: // Beige
					GameManager.instance.SetBeigeHealth (4);
					break;
				case 2: // Blue
					GameManager.instance.SetBlueHealth (4);
					break;
				case 3: // Green
					GameManager.instance.SetGreenHealth (4);
					break;
				case 4: // Pink
					GameManager.instance.SetPinkHealth (4);
					break;
				case 5: // Yellow
					GameManager.instance.SetYellowHealth (4);
					break;
			}
		} else {
			shopWindow.SetActive (true);
		}
	}

	public void Go () {
		if (GameManager.instance.GetHealth () == 0) {
			GameObject.Find ("LowLifeWindow").SetActive (false);
		} else if (GameManager.instance.GetLives () == 0) {
			lowLiveWindow.SetActive (true);
		} else {
			if (GameObject.Find ("Character") != null) {
				GameManager.instance.SetLoadingScene (character.currentPin.SceneToLoad);
			} else {
				GameManager.instance.SetLoadingScene (SceneManager.GetActiveScene ().name);
			}
			Time.timeScale = 1;
			SceneManager.LoadScene ("LoadingScreen");
		}
	}
}
